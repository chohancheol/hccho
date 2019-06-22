using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _87_Compress
    {
        public void Test()
        {
            String text = "AAAAAAAAAAAAAAABBDDDCCDDED";


            //15A2B3D2C2DED
            String encodeText = encode(text);
            String decodeText = decode(encodeText);
            Console.WriteLine(encodeText);
            Console.WriteLine(decodeText);
            Console.WriteLine(text.Equals(decodeText));


            Console.WriteLine();

            //A15B2D3C2D2DED
            String encodeText2 = encode2(text);
            String decodeText2 = decode2(encodeText2);
            Console.WriteLine(encodeText2);
            Console.WriteLine(decodeText2);
            Console.WriteLine(text.Equals(decodeText2));
        }

        public static String encode(String source)
        {
            StringBuilder dest = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                int runLength = 1;
                while (i + 1 < source.Length && source.Substring(i, 1) == source.Substring(i + 1, 1))
                {
                    runLength++;
                    i++;
                }
                if (runLength != 1)
                    dest.Append(runLength);
                dest.Append(source.Substring(i, 1));
            }
            return dest.ToString();
        }

        public static String decode(String encoding)
        {
            StringBuilder dest = new StringBuilder();
            for (int i = 0; i < encoding.Length; i++)
            {
                StringBuilder countStr = new StringBuilder();
                while (i + 1 < encoding.Length
                        && isDigit(encoding.Substring(i, 1)))
                {
                    countStr.Append(encoding.Substring(i, 1));
                    i++;
                }
                int count = countStr.ToString().Equals("") ? 1 : int.Parse(countStr.ToString());
                for (int num = 0; num < count; num++)
                    dest.Append(encoding.Substring(i, 1));
            }
            return dest.ToString();
        }

        public static bool isDigit(string i)
        {
            int iout;
            return int.TryParse(i, out iout);
        }
        public static String encode2(String source)
        {
            StringBuilder dest = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                int runLength = 1;
                while (i + 1 < source.Length && source.Substring(i, 1) == source.Substring(i + 1, 1))
                {
                    runLength++;
                    i++;
                }

                dest.Append(source.Substring(i, 1));
                if (runLength != 1)
                    dest.Append(runLength);
            }
            return dest.ToString();
        }

        public static String decode2(String encoding)
        {
            StringBuilder dest = new StringBuilder();
            int i = 0;
            while (i < encoding.Length)
            {
                string c = string.Empty;
                if (!isDigit(encoding.Substring(i, 1)))
                {
                    c = encoding.Substring(i, 1);
                    i++;
                }

                StringBuilder countStr = new StringBuilder();
                while (i + 1 < encoding.Length
                        && isDigit(encoding.Substring(i, 1)))
                {
                    countStr.Append(encoding.Substring(i, 1));
                    i++;
                }
                int count = countStr.ToString().Equals("") ? 1 : int.Parse(countStr.ToString());
                for (int num = 0; num < count; num++)
                    dest.Append(c);
            }
            return dest.ToString();
        }

    }
}
