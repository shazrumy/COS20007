using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawing
{
    // Drawing manages a collection of different shape types and handles the background
    public class Drawing
    {
        // POLYMORPHISM IN ACTION: This list can hold different types of shapes
        // (rectangles, circles, lines) all treated as "Shape" objects
        private readonly List<Shape> _shapes;
        
        // Store what color the background should be
        private Color _background;

        // Create a new drawing with a specific background color
        public Drawing(Color background)
        {
            // Start with an empty list of shapes
            _shapes = new List<Shape>();
            // Set the background color
            _background = background;
        }

        // Create a new drawing with white background (default)
        public Drawing() : this(Color.White)
        {
            // This calls the other constructor with white background
        }

        // Get or change the background color
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        // Find out how many shapes are in this drawing
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        // POLYMORPHISM: We can add any type of shape (rectangle, circle, line) to the same method
        // The method doesn't need to know what specific type it is - it just knows it's a Shape
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        // Remove a shape from this drawing
        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }

        // POLYMORPHISM MAGIC: One method, many behaviors!
        public void Draw()
        {
            // Clear the screen with the background color
            SplashKit.ClearScreen(_background);
            
            // POLYMORPHISM: Each shape.Draw() calls a DIFFERENT method depending on the actual type:
            // - If shape is MyRectangle, calls MyRectangle.Draw() (draws filled rectangle)
            // - If shape is MyCircle, calls MyCircle.Draw() (draws filled circle)  
            // - If shape is MyLine, calls MyLine.Draw() (draws line)
            // Same method call, different behaviors = POLYMORPHISM!
            foreach (Shape shape in _shapes)
            {
                shape.Draw(); // This calls the correct Draw method for each shape type
            }
        }

        // POLYMORPHISM MAGIC: One method call, many different behaviors!
        public void SelectShapesAt(Point2D pt)
        {
            // Check every shape to see if the click was inside it
            foreach (Shape s in _shapes)
            {
                // POLYMORPHISM: Each s.IsAt(pt) calls a DIFFERENT method depending on the actual type:
                // - If s is MyRectangle, calls MyRectangle.IsAt() (rectangle boundary check)
                // - If s is MyCircle, calls MyCircle.IsAt() (circle boundary check)
                // - If s is MyLine, calls MyLine.IsAt() (line proximity check)
                // Same method call, different behaviors = POLYMORPHISM!
                s.Selected = s.IsAt(pt); // This calls the correct IsAt method for each shape type
            }
        }

        // Get a list of all currently selected shapes
        public List<Shape> SelectedShapes
        {
            get
            {
                // Create a new list to hold the selected shapes
                List<Shape> result = new List<Shape>();
                
                // Look through all shapes and add the selected ones to our list
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