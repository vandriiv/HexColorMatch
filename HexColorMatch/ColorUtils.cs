namespace HexColorMatch
{
    internal static class ColorUtils
    {
        public static string GetClosestColorName(string staticHexColor)
        {
            using (var context = new MyDbContext()) // replace DbContext with your actual context class
            {
                // get all HexColors from the database
                var hexColors = context.HexColors.ToList();

                // convert staticHexColor to bytes
                byte[] staticBytes = GetBytesFromHexColor(staticHexColor);

                Console.WriteLine("Static bytes:");
                foreach (byte b in staticBytes)
                {
                    Console.Write("{0:x2} ", b);
                }

                double minDistance = double.MaxValue;
                string closestColorName = null;

                // find the color with the highest percentage match
                double highestMatch = 0.0;
                string closesthexcolor = "";

                foreach (HexColor hexColor in hexColors)
                {
                    byte[] dynamicBytes = GetBytesFromHexColor(hexColor.HexCode);

                    Console.WriteLine("Dynamic bytes for {0}:", hexColor.Name);
                    foreach (byte b in dynamicBytes)
                    {
                        Console.Write("{0:x2} ", b);
                    }
                    Console.WriteLine();

                    double distance = CalculateProximity(staticBytes, dynamicBytes);

                    Console.WriteLine("Match distance for {0}: {1}", hexColor.Name, distance);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestColorName = hexColor.Name;
                        closesthexcolor = hexColor.HexCode;
                    }
                }

                return closesthexcolor + "_" + closestColorName;
            }
        }

        private static byte[] GetBytesFromHexColor(string hexCode)
        {
            var formatted = hexCode.Replace("#", "");

            byte red = byte.Parse(formatted.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte green = byte.Parse(formatted.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte blue = byte.Parse(formatted.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            return new byte[] { red, green, blue };
        }

        public static double CalculateProximity(byte[] color1, byte[] color2)
        {
            double rDiff = color1[0] - color2[0];
            double gDiff = color1[1] - color2[1];
            double bDiff = color1[2] - color2[2];

            double distance = Math.Sqrt(rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);

            return distance;
        }
    }
}
