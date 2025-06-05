using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    // INHERITANCE: This is the BASE CLASS (parent) that other shapes inherit from
    // Abstract base class for all shapes - cannot create Shape objects directly
    public abstract class Shape
    {
        // INHERITANCE: All child classes will have these same properties automatically
        // Store the shape's color, position, and selection state
        private Color _color;          // What color the shape is
        private float _x, _y;          // Where the shape is on screen
        private bool _selected;        // Whether this shape is currently selected

        // Default constructor - uses yellow color
        public Shape() : this(Color.Yellow)
        {
        }

        // Create a shape with a specific color at position (0, 0)
        public Shape(Color color)
        {
            _color = color;           // Use the color provided
            _x = 0.0f;               // Start at top-left corner
            _y = 0.0f;
            _selected = false;        // Start unselected
        }

        // INHERITANCE: All child classes will have these same properties and can use them
        // Get or change the shape's color
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // Get or change where the shape is horizontally
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        // Get or change where the shape is vertically
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        // Check if this shape is currently selected (highlighted)
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        // POLYMORPHISM: These abstract methods MUST be implemented differently by each child class
        // Each shape type (rectangle, circle, line) will have its own unique way of doing these
        public abstract void Draw();                    // Draw the shape on screen
        public abstract void DrawOutline();             // Draw outline when selected
        public abstract bool IsAt(Point2D pt);          // Check if point is inside shape
    }
}