using System;
using SplashKitSDK;

namespace DrawingShape
{
    public class Program
    {
        public static void Main()
        {
            // Create a new shape object
            Shape myShape = new Shape();

            // Create a window for drawing
            new Window("Drawing Shape", 800, 600);
            
            // Main game loop - keeps running until window is closed
            do
            {
                // Handle any events (like mouse clicks, key presses)
                SplashKit.ProcessEvents();
                
                // Clear the screen to prepare for new drawing
                SplashKit.ClearScreen();

                // If user clicks left mouse button, move shape to mouse position
                if(SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = (float)SplashKit.MouseX();
                    myShape.Y = (float)SplashKit.MouseY();
                }

                // If mouse is hovering over the shape and spacebar is held down, change color
                if(myShape.IsAt(SplashKit.MousePosition()))
                {
                    if(SplashKit.KeyDown(KeyCode.SpaceKey))
                    {
                        myShape.Color = Color.RandomRGB(255);
                    }
                }

                // Draw the shape on screen
                myShape.Draw();

                // Update the display with everything that was drawn
                SplashKit.RefreshScreen();

            }
            while (!SplashKit.WindowCloseRequested("Drawing Shape")); // Continue until user closes window
        }
    }
}
