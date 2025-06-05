using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    // INHERITANCE: MyCircle IS-A Shape (inherits from Shape base class)
    // This means MyCircle automatically gets all Shape properties (Color, X, Y, Selected)
    public class MyCircle : Shape
    {
        // Store how big the circle is
        private int _radius;

        // INHERITANCE: We call the parent constructor to initialize shared properties
        public MyCircle(Color color, float x, float y, int radius) : base(color)
        {
            X = x;                    // Using inherited property from Shape
            Y = y;                    // Using inherited property from Shape
            Radius = radius;          // Set how big the circle is
        }

        // Create a default circle (blue, at origin, size based on student ID)
        public MyCircle() : this(Color.Blue, 0.0f, 0.0f, 50 + 47)
        {
            // Student ID: 104100247 -> last two digits are 47
            // So radius = 50 + 47 = 97
        }

        // Get or change how big the circle is (distance from center to edge)
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        // POLYMORPHISM: Circle's unique way of drawing (overrides abstract method from Shape)
        // This is DIFFERENT from how Rectangle draws, but uses the same method name
        public override void Draw()
        {
            // Using inherited properties: Selected, Color, X, Y
            if (Selected)
            {
                DrawOutline();
            }
            // Circle draws as a filled circle (different from Rectangle's filled rectangle)
            SplashKit.FillCircle(Color, X, Y, Radius);
        }

        // POLYMORPHISM: Circle's unique way of drawing outline (different from Rectangle and Line)
        public override void DrawOutline()
        {
            // Circle outline is a bigger black circle (different from Rectangle's approach)
            SplashKit.FillCircle(Color.Black, X, Y, Radius + 2);
        }

        // POLYMORPHISM: Circle's unique way of checking if point is inside (different from Rectangle and Line)
        public override bool IsAt(Point2D pt)
        {
            // Circle uses circular boundary checking (different from Rectangle's rectangular checking)
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius));
        }
    }
}
