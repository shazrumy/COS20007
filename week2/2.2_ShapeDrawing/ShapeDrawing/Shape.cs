using System;
using System.Collections.Generic;
using System.Drawing;  // Add this at the top with other using statements
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawing
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        public Shape(int param)
        {
            _color = Color.Chocolate; //Setting initial color
            _x = _y = 0.0f; //Setting initial starting coords
            _width = _height = 147; //Setting shape dimesions. student ID is 104100247
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Width 
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public void Draw()
        {
            Console.WriteLine("Color is " + _color.Name);
            Console.WriteLine("Position X is " + _x);
        }
        public bool IsAt(int xInput, int yInput)
        {
            // Check if the point is within the rectangular bounds of the shape
            // Point must be:
            // - Greater than or equal to the left edge (_x)
            // - Less than the right edge (_x + _width)
            // - Greater than or equal to the top edge (_y)
            // - Less than the bottom edge (_y + _height)
            
            return (xInput >= _x && xInput < _x + _width && 
                    yInput >= _y && yInput < _y + _height);
        }
    }
}