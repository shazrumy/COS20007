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

        // Constructor - sets up initial values when creating a new shape
        public Shape()
        {
            _color = Color.Chocolate; // Setting initial color. First name letter is "S" -> Color.Chocolate
            _x =_y = 0; // Setting initial starting coords
            _width = _height = 147; // Setting shape dimensions. 1XX where XX is two last letter of student ID -> 104100247 -> 147!
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
        
        // Method to draw the shape on screen as a filled rectangle
        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        // Method to check if a given point is inside the shape's area
        public bool IsAt(Point2D p)
        {
            return SplashKit.PointInRectangle(p, SplashKit.RectangleFrom(X,Y, _width, _height));
        }
    }
}