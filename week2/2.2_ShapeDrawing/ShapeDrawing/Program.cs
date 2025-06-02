using System;

namespace ShapeDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add a myShape local variable of the type Shape
            ShapeDrawing.Shape myShape;

            // Assign myShape, a new Shape object using the Shape constructor
            myShape = new ShapeDrawing.Shape(0);

            // Tell myShape to Draw itself
            myShape.Draw();

            // Keep console open
            Console.ReadLine();
        }
    }
}