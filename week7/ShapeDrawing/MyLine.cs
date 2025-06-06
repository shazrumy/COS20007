using System;
using System.IO;
using SplashKitSDK;
using MyGame;  // For extension methods

namespace ShapeDrawing
{
    // INHERITANCE: MyLine IS-A Shape (inherits from Shape base class)
    // This means MyLine automatically gets all Shape properties (Color, X, Y, Selected)
    public class MyLine : Shape
    {
        // Store where the line ends
        private float _endX, _endY;

        // INHERITANCE: We call the parent constructor to initialize shared properties
        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;               // Using inherited property from Shape
            Y = startY;               // Using inherited property from Shape
            EndX = endX;              // Set where line ends horizontally
            EndY = endY;              // Set where line ends vertically
        }

        // Create a default line (red, from origin to a fixed point)
        public MyLine() : this(Color.Red, 0.0f, 0.0f, 100.0f, 100.0f)
        {
            // Default line goes from (0,0) to (100,100)
        }

        // Get or change where the line ends horizontally
        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        // Get or change where the line ends vertically
        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        // POLYMORPHISM: Line's unique way of drawing (overrides abstract method from Shape)
        // This is DIFFERENT from both Rectangle and Circle, but uses the same method name
        public override void Draw()
        {
            // Using inherited properties: Selected, Color, X, Y
            if (Selected)
            {
                DrawOutline();
            }
            // Line draws as a line (different from Rectangle's rectangle and Circle's circle)
            SplashKit.DrawLine(Color, X, Y, EndX, EndY);
        }

        // POLYMORPHISM: Line's unique way of drawing outline (different from Rectangle and Circle)
        public override void DrawOutline()
        {
            // Line outline uses small circles at endpoints (completely different approach)
            SplashKit.FillCircle(Color.Black, X, Y, 5);         // Circle at start point
            SplashKit.FillCircle(Color.Black, EndX, EndY, 5);   // Circle at end point
        }

        // POLYMORPHISM: Line's unique way of checking if point is inside (different from Rectangle and Circle)
        public override bool IsAt(Point2D pt)
        {
            // Line uses line-proximity checking (different from Rectangle and Circle)
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY));
        }

        // POLYMORPHISM: Line's unique way of saving to file
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");           // Shape type identifier
            base.SaveTo(writer);               // Save base class properties (Color, X, Y)
            writer.WriteLine(EndX);            // End X position
            writer.WriteLine(EndY);            // End Y position
        }
        
        // POLYMORPHISM: Line's unique way of loading from file
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);             // Load base class properties (Color, X, Y)
            EndX = reader.ReadSingle();        // Load end X position
            EndY = reader.ReadSingle();        // Load end Y position
        }
    }
}
