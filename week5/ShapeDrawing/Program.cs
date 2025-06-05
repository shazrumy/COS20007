using System;
using SplashKitSDK;

namespace DrawingShape
{
    public class Program
    {
        public static void Main()
        {
            // Create a new drawing with default constructor (white background)
            Drawing myDrawing = new Drawing();
            
            // Create the window
            new Window("Shape Drawer - Multiple Shapes", 800, 600);
            
            // Main event loop
            do
            {
                // Process events
                SplashKit.ProcessEvents();

                // Check if user clicked left mouse button - add new shape
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Create new shape at mouse position
                    Shape newShape = new Shape((int)SplashKit.MouseX(), (int)SplashKit.MouseY());
                    myDrawing.AddShape(newShape);
                }

                // Check if user clicked right mouse button - select shapes
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }

                // Check if user pressed space bar - change background color
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                // Check if user pressed delete or backspace - remove selected shapes
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    myDrawing.RemoveSelectedShapes();
                }

                // Draw the drawing (this clears screen and draws all shapes)
                myDrawing.Draw();

                // Refresh the screen
                SplashKit.RefreshScreen();
            }
            while (!SplashKit.WindowCloseRequested("Shape Drawer - Multiple Shapes"));
        }
    }
}
