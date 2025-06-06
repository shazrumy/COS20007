using System;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;
using MyGame;

namespace ShapeDrawing
{
    // Drawing manages a collection of shapes and handles the background
    public class Drawing
    {
        // POLYMORPHISM: List can hold different types of shapes (rectangles, circles, lines)
        private readonly List<Shape> _shapes;
        
        // Store background color
        private Color _background;

        // Create drawing with specific background color
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        // Create drawing with white background (default)
        public Drawing() : this(Color.White)
        {
        }

        // Get or change the background color
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        // Get number of shapes in this drawing
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        // POLYMORPHISM: Add any type of shape to the same method
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        // Remove a shape from this drawing
        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }

        // Save drawing to file
        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteColor(_background);
                writer.WriteLine(ShapeCount);

                // POLYMORPHISM: Each shape saves itself differently
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        // Load drawing from file
        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                Background = reader.ReadColor();
                int count = reader.ReadInteger();
                _shapes.Clear();
                
                for (int i = 0; i < count; i++)
                {
                    string? kind = reader.ReadLine();
                    Shape? s = null;
                    
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }
                    
                    if (s != null)
                    {
                        // POLYMORPHISM: Each shape loads itself differently
                        s.LoadFrom(reader);
                        AddShape(s);
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }

        // Draw all shapes on screen
        public void Draw()
        {
            // Clear screen with background color
            SplashKit.ClearScreen(_background);

            // POLYMORPHISM: Each shape draws itself differently
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        // Select shapes at the clicked point
        public void SelectShapesAt(Point2D pt)
        {
            // POLYMORPHISM: Each shape checks if point is inside differently
            foreach (Shape s in _shapes)
            {
                s.Selected = s.IsAt(pt);
            }
        }

        // Get list of all currently selected shapes
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }
    }
}