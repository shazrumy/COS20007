using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    // INHERITANCE: MyRectangle IS-A Shape (inherits from Shape base class)
    // This means MyRectangle automatically gets all Shape properties (Color, X, Y, Selected)
    public class MyRectangle : Shape
    {
        // Store the rectangle's size
        private int _width, _height;

        // INHERITANCE: We call the parent constructor to initialize shared properties
        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;                    // Using inherited property from Shape
            Y = y;                    // Using inherited property from Shape
            Width = width;            // Set how wide it is
            Height = height;          // Set how tall it is
        }

        // Create a default rectangle (green, at origin, size based on student ID)
        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 100 + 47, 100 + 47)
        {
            // Student ID: 104100247 -> last two digits are 47
            // So width and height = 100 + 47 = 147
        }

        // Get or change how wide the rectangle is
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        // Get or change how tall the rectangle is
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        // POLYMORPHISM: Rectangle's unique way of drawing (overrides abstract method from Shape)
        public override void Draw()
        {
            // Using inherited properties: Selected, Color, X, Y
            if (Selected)
            {
                DrawOutline();
            }
            // Rectangle draws as a filled rectangle
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        // POLYMORPHISM: Rectangle's unique way of drawing outline (different from Circle and Line)
        public override void DrawOutline()
        {
            // Make outline 12 pixels bigger on all sides (5 + 7, where 7 is from student ID)
            int outlineWidth = 5 + 7; 
            
            // Rectangle outline is a bigger black rectangle
            SplashKit.FillRectangle(
                Color.Black,                           // Black outline color
                X - outlineWidth,                      // Start further left
                Y - outlineWidth,                      // Start further up
                Width + (outlineWidth * 2),            // Make wider on both sides
                Height + (outlineWidth * 2)            // Make taller on both sides
            );
        }

        // POLYMORPHISM: Rectangle's unique way of checking if point is inside (different from Circle and Line)
        public override bool IsAt(Point2D pt)
        {
            // Rectangle uses rectangular boundary checking
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, Width, Height));
        }
    }
}
