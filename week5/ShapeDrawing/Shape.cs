using System;
using SplashKitSDK;

namespace DrawingShape
{
    public class Shape
    {
        // Private fields to store shape properties
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        // Constructor - creates shape at specified position
        public Shape(int x, int y)
        {
            _color = Color.Chocolate; // Setting initial color
            _x = x;
            _y = y;
            _width = _height = 147; // Setting shape dimensions. Student ID: 104100247 -> 147
            _selected = false; // Default to not selected
        }

        // Property to get and set the shape's color
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // Property to get and set the shape's X position
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        // Property to get and set the shape's Y position
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        // Property to get and set the shape's width
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        // Property to get and set the shape's height
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        // Property to get and set whether the shape is selected
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        // Method to draw the shape on screen
        public void Draw()
        {
            // Draw outline first if selected (so it appears behind the shape)
            if (Selected)
            {
                DrawOutline();
            }
            // Draw the filled rectangle
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        // Method to check if a point is within the shape's area
        public bool IsAt(Point2D p)
        {
            return SplashKit.PointInRectangle(p, SplashKit.RectangleFrom(_x, _y, _width, _height));
        }

        // Method to draw a black outline around the shape when selected
        public void DrawOutline()
        {
            // Black rectangle has to be (5+X) pixels wider on all sides
            // where X is the last digit of student ID (104100247 -> 7)
            int outlineWidth = 5 + 7; // 12 pixels wider on all sides
            
            SplashKit.FillRectangle(
                Color.Black, 
                _x - outlineWidth, 
                _y - outlineWidth, 
                _width + (outlineWidth * 2), 
                _height + (outlineWidth * 2)
            );
        }
    }
}