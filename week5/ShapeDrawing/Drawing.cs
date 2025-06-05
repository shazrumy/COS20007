using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace DrawingShape
{
    // Drawing class manages a collection of Shape objects
    public class Drawing
    {
        // Private fields to store shapes and background
        private readonly List<Shape> _shapes;
        private Color _background;

        // Constructor that takes a background color
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        // Default constructor - uses white background
        public Drawing() : this(Color.White)
        {
            // All initialization handled by the other constructor
        }

        // Property to get and set the background color
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        // Read-only property that returns the number of shapes
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        // Read-only property that returns a list of selected shapes
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

        // Method to add a shape to the drawing
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        // Method to remove a shape from the drawing
        public void RemoveShape(Shape shape)
        {
            _ = _shapes.Remove(shape);
        }

        // Method to draw all shapes in the drawing
        public void Draw()
        {
            // Clear screen with background color
            SplashKit.ClearScreen(_background);
            
            // Draw each shape
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        // Method to select/deselect shapes at a given point
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                // Set selected to true if shape is at the point, false otherwise
                s.Selected = s.IsAt(pt);
            }
        }

        // Method to remove all selected shapes
        public void RemoveSelectedShapes()
        {
            // Get list of selected shapes first
            List<Shape> selectedShapes = SelectedShapes;
            
            // Remove each selected shape
            foreach (Shape shape in selectedShapes)
            {
                RemoveShape(shape);
            }
        }
    }
}
