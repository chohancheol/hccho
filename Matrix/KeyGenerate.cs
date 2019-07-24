using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class KeyGenerate
    {
        private static char[] characterArray = new char[]
        {
            '0', '1', '2', '3', '4',
            '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E',
            'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O',
            'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y',
            'Z'
        };


        public static void KeyGen()
        {
            string year = "2019";
            string userName = "abcd";
            string maxAddress = "127.0.0.1";

            StringBuilder stringBuilder1 = new StringBuilder();

            stringBuilder1.Append(characterArray[Convert.ToInt32(year) % 36]);

            stringBuilder1.Append(characterArray[Convert.ToInt32(year.Substring(0, 1))]);
            stringBuilder1.Append(characterArray[Convert.ToInt32(year.Substring(2, 1))]);
            stringBuilder1.Append(characterArray[Convert.ToInt32(year.Substring(3, 1))]);
            stringBuilder1.Append(maxAddress);
            stringBuilder1.Append(maxAddress.Substring(0, 1));
            stringBuilder1.Append(maxAddress.Substring(1, 1));
            stringBuilder1.Append(GetMD5Hash(userName).Substring(0, 1));
            stringBuilder1.Append(GetMD5Hash(userName).Substring(29, 1));

            string keyList = stringBuilder1.ToString().ToUpper();

            char[] keyArray = keyList.ToCharArray();
            int[] keyValueArray = new int[keyArray.Length];

            int add = DateTime.Now.Year;
            int z;

            int value0 = 0;
            int value1 = 0;
            int value2 = 0;
            int value3 = 0;
            int value4 = 0;

            StringBuilder stringBuilder2 = new StringBuilder();

            for (int i = 0; i < keyArray.Length; i++)
            {
                z = (i + 10) * add;

                keyValueArray[i] = (int)keyArray[i];

                stringBuilder2.Append(characterArray[(z ^ keyValueArray[i]) % 36]);

                if (((i + 1) % 5 == 0))
                {
                    stringBuilder2.Append("-");
                }

                switch (i % 5)
                {
                    case 0: value0 += ((z ^ keyValueArray[i]) % 36); break;
                    case 1: value1 += ((z ^ keyValueArray[i]) % 36); break;

                    case 2: value2 += ((z ^ keyValueArray[i]) % 36); break;
                    case 3: value3 += ((z ^ keyValueArray[i]) % 36); break;
                    case 4: value4 += ((z ^ keyValueArray[i]) % 36); break;
                }
            }

            stringBuilder2.Append(characterArray[value0 % 36]);
            stringBuilder2.Append(characterArray[value1 % 36]);
            stringBuilder2.Append(characterArray[value2 % 36]);
            stringBuilder2.Append(characterArray[value3 % 36]);
            stringBuilder2.Append(characterArray[value4 % 36]);

            stringBuilder2.ToString();

            Console.WriteLine(stringBuilder2);

            Console.ReadKey();
        }

        private static string GetMD5Hash(string text)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();

            Byte[] hashArray = md5.ComputeHash(Encoding.Default.GetBytes(text));

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < hashArray.Length - 1; i++)
            {
                stringBuilder.AppendFormat("{0:x2}", hashArray[i]);
            }

            return stringBuilder.ToString();
        }


        public static long GetDirectorySize(string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            long directorySize = 0L;

            foreach (FileInfo fileInfo in directoryInfo.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                directorySize += fileInfo.Length;
            }

            return directorySize;
        }

    }
}

