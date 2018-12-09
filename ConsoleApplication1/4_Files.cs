using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _4_Files
    {
        public void TextFile()
        {
            string line;
            // 1. 샘플: 텍스트 라인별 읽기
            // StreamReader 객체를 생성한다. 입력파라미터로 File Path나 파일스트림 사용한다.
            using (StreamReader rdr = new StreamReader(@"C:\Temp\data.txt"))
            {
                // ReadLine()을 써서 한 라인을 읽어 들인다
                // 만약 파일 끝이면 null 이 리턴된다
                while ((line = rdr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            // 2. 샘플: 텍스트 문자 몇 개만 읽기
            using (StreamReader rdr = new StreamReader(@"C:\Temp\data.txt"))
            {
                // 한 문자 읽기
                int ch = rdr.Read();
                Console.Write(ch);

                // 현재 파일 포인터 위치에서 10개 문자를 읽기
                char[] buffer = new char[10];
                int readCount = rdr.Read(buffer, 0, 10);
                Console.WriteLine(buffer);
            }

            // 텍스트 파일 쓰기            
            // StreamWriter 객체를 생성한다. 입력파라미터로 File Path나 파일스트림 사용한다.
            using (StreamWriter wr = new StreamWriter(@"C:\Temp\data.txt"))
            {
                // WriteLine()을 써서 한 라인씩 문자열을 쓴다.                
                wr.WriteLine("Line 1");
                wr.WriteLine("Line 2");

                // 숫자를 쓰기
                decimal val = 1024.10M;
                wr.WriteLine(val);

                // 문자배열을 쓰기
                char[] array = new char[5] { 'A', 'B', 'C', 'D', 'E' };
                wr.WriteLine(array);
            }



            // ###### 텍스트 파일 읽기  ######
            // 모든 텍스트 한꺼번에 읽기
            string data = File.ReadAllText(@"C:\Temp\data.txt");
            Console.WriteLine(data);

            // 모든 라인들을 읽어 문자열 배열에 넣기
            string[] allLines = File.ReadAllLines(@"C:\Temp\data.txt");

            // 한 라인씩 읽기
            IEnumerable<string> lines = File.ReadLines(@"C:\Temp\data.txt");
            foreach (string line1 in lines)
            {
                Console.WriteLine(line1);
            }


            // ###### 텍스트 파일 쓰기  ######
            // 텍스트 파일에 모든 데이타 한꺼번에 쓰기
            File.WriteAllText("data.out", data);

            //// 텍스트 파일에 문자열배열 라인별로 쓰기
            string[] arrStr = { "I", "am", "a", "boy" };
            File.WriteAllLines("data.out", arrStr);

            // 텍스트 파일에 모든 데이타 한꺼번에 추가(append)
            File.AppendAllText("data.out", data);

            // 텍스트 파일에 문자열배열 한꺼번에 추가(append)
            File.AppendAllLines("data.out", allLines);
        }



        public void BinaryFile()
        {
            // 이진파일에 쓸 샘플데이타
            bool b = true;
            int i = 101;
            decimal d = 1024.05M;
            byte by = 0xA0;
            byte[] bytes = { 0xFF, 0x32, 0x11 };
            string s = "Hello";

            // 이진파일 생성
            FileStream fs = File.Open(@"C:\Temp\data.bin", FileMode.Create);

            // BinaryWriter는 파일스트림을 사용해서 객체를 생성한다
            using (BinaryWriter wr = new BinaryWriter(fs))
            {
                // 각각의 샘플데이타를 이진파일에 쓴다
                wr.Write(b);  // bool 
                wr.Write(i);  // 정수
                wr.Write(d);  // decimal
                wr.Write(by); // byte
                wr.Write(bytes); // bytes
                wr.Write(s);  // 문자열 (UTF8)
            }


            // BinaryReader는 스트림을 사용해서 객체를 생성한다
            using (BinaryReader rdr = new BinaryReader(File.Open(@"C:\Temp\data.bin", FileMode.Open)))
            {
                // 각 데이타 타입별로 다양한 Read 메서드를 사용한다
                bool b1 = rdr.ReadBoolean();
                int i1 = rdr.ReadInt32();
                decimal d1 = rdr.ReadDecimal();
                byte by1 = rdr.ReadByte();
                byte[] bytes1 = rdr.ReadBytes(3); // 3바이트 읽기
                string s1 = rdr.ReadString();

                Console.WriteLine("{0},{1},{2}", b1, i1, s1);
            }



            // 이진파일에서 문자열 인코딩
            string datafile = "data.bin";

            FileStream fw = File.Open(datafile, FileMode.Create);
            using (BinaryWriter wr = new BinaryWriter(fw, Encoding.UTF7))
            {
                // 문자 데이타에 UTF7 인코딩이 사용됨
                wr.Write("안녕하세요?");
                wr.Write('한');
            }

            var fr = File.Open(datafile, FileMode.Open);
            // using (BinaryReader rdr = new BinaryReader(fr, Encoding.UTF7))  // 맞는 코드
            using (BinaryReader rdr = new BinaryReader(fr))  // 틀린코드 (디폴트 UTF8)
            {
                // 문자 데이타 읽기. 지정된 인코딩 사용함.
                string s2 = rdr.ReadString();
                char c2 = rdr.ReadChar();

                Console.WriteLine("{0},{1}", s2, c2);
            }


            // File 클래스를 통해 전체 바이트 읽고 쓰기
            // 이미지 파일에서 전체 바이트 읽기
            byte[] bytes2 = File.ReadAllBytes(@"C:\Temp\source.png");

            // 이미지 파일에 모든 바이트 쓰기
            File.WriteAllBytes(@"C:\Temp\target.png", bytes2);


            //FileStream 클래스를 통한 파일 읽고 쓰기 
            using (FileStream fs2 = new FileStream(@"C:\Temp\source.png", FileMode.Open))
            {
                int size = (int)fs.Length;
                byte[] buff = new byte[size];

                // 이미지를 10번에 걸쳐 나누어 읽음
                for (int i2 = 0; i2 < 10; i++)
                {
                    int n = fs.Read(buff, 0, size / 10);
                    //....
                    Console.WriteLine(n);
                }
            }
        }
    }
}
