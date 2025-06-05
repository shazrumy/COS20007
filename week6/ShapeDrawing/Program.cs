using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    // Main program - handles the window and user input for multiple shape types
    public class Program
    {
        // Enumeration to track what type of shape the user wants to create
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            // Create a window for drawing shapes
            SplashKit.OpenWindow("Shape Drawer", 800, 600);

            // Create our drawing canvas (starts with white background)
            Drawing myDrawing = new Drawing();

            // Keep track of what kind of shape to create when user clicks
            ShapeKind kindToAdd = ShapeKind.Circle;  // Start with circles

            // Keep running until user closes the window
            do
            {
                // Check for keyboard and mouse input
                SplashKit.ProcessEvents();

                // R KEY: Switch to creating rectangles
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                // C KEY: Switch to creating circles  
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                // L KEY: Switch to creating lines
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                // LEFT CLICK: Add a new shape where the user clicked
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape; // POLYMORPHISM: This variable can hold any type of shape

                    // Create different types of shapes based on what user selected
                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            // INHERITANCE: MyCircle IS-A Shape, so we can assign it to Shape variable
                            newShape = new MyCircle();
                            break;
                        case ShapeKind.Line:
                            // INHERITANCE: MyLine IS-A Shape, so we can assign it to Shape variable
                            newShape = new MyLine(Color.Red, 
                                                 SplashKit.MouseX(), SplashKit.MouseY(),
                                                 SplashKit.MouseX() + 100, SplashKit.MouseY() + 50);
                            break;
                        default: // Rectangle
                            // INHERITANCE: MyRectangle IS-A Shape, so we can assign it to Shape variable
                            newShape = new MyRectangle();
                            break;
                    }

                    // INHERITANCE: All shapes have X and Y properties from the base Shape class
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    
                    // POLYMORPHISM: AddShape accepts any type of shape (rectangle, circle, or line)
                    myDrawing.AddShape(newShape);
                }

                // RIGHT CLICK: Select shapes where the user clicked
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D mousePoint = SplashKit.MousePosition();
                    // POLYMORPHISM: This method works with all shape types automatically
                    myDrawing.SelectShapesAt(mousePoint);
                }

                // SPACEBAR: Change background to a random color
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = Color.RandomRGB(255);
                }

                // DELETE/BACKSPACE: Remove all selected shapes
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    // POLYMORPHISM: SelectedShapes can contain any mix of rectangles, circles, and lines
                    var selectedShapes = myDrawing.SelectedShapes;
                    // POLYMORPHISM: RemoveShape works with any type of shape
                    foreach (Shape shape in selectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                // POLYMORPHISM: Draw() automatically calls the right drawing method for each shape type
                myDrawing.Draw();

                // Refresh the screen
                SplashKit.RefreshScreen(60);

            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));

            // Close the window
            SplashKit.CloseWindow("Shape Drawer");
        }
    }
}
