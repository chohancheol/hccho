using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _84_pattern
    {
        List<int> vip = new List<int> { 1, 3, 5, 9 };
        List<int> active = new List<int> { 10, 13, 15, 19 };
        List<int> blacklist = new List<int> { 7, 14, 12, 133 };


        /* 2017이상에서 사용 가능
        public void CheckCustomer(int id)
        {
            switch (id)
            {
                case var _id when (vip.Contains(_id)): Console.WriteLine("VIP");
                    // VIP 
                    break;
                case var _id when (active.Contains(_id)):Console.WriteLine("ACTIVE");
                    //...
                    break;
                case var _id when (blacklist.Contains(_id)):Console.WriteLine("BLACLIST");
                    //...
                    break;
                default:
                    //...
                    break;
            }
        }
        */

        public void binToString()
        {
            string binData = "0110100100000000010100000000000001100001000000000110010000000000";

            int nbytes = binData.Length / 8;
            byte[] outBytes = new byte[nbytes];


            for (int i = 0; i < nbytes; i++)
            {
                // 8자리 숫자 즉 1바이트 문자열 얻기
                string binStr = binData.Substring(i * 8, 8);
                // 2진수 문자열을 숫자로 변경
                outBytes[i] = (byte)Convert.ToInt32(binStr, 2);
            }

            // Unicode 인코딩으로 바이트를 문자열로
            string result = UnicodeEncoding.Unicode.GetString(outBytes);
            Console.WriteLine(result);
        }
    }
}
