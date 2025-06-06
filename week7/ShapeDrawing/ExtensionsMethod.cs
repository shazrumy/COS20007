using System;
using System.IO;
using SplashKitSDK;

namespace MyGame
{
    public static class ExtensionsMethods
    {
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }
        
        public static float ReadSingle(this StreamReader reader)
        {
            return Convert.ToSingle(reader.ReadLine());
        }
        
        public static Color ReadColor(this StreamReader reader)
        {
            return SplashKit.RGBColor(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }
        
        public static void WriteColor(this StreamWriter writer, Color clr)
        {
            writer.WriteLine(clr.R);
            writer.WriteLine(clr.G);
            writer.WriteLine(clr.B);
        }
    }
}
