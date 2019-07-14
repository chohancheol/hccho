using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Network
{
    class FileSample
    {
        public void FileProcss()
        {
            string line;
            // 1. 샘플: 텍스트 라인별 읽기
            // StreamReader 객체를 생성한다. 입력파라미터로 File Path나 파일스트림 사용한다.

            List<Student> students = new List<Network.Student>();
            using (StreamReader rdr = new StreamReader(@"Student.txt"))
            {
                // ReadLine()을 써서 한 라인을 읽어 들인다
                // 만약 파일 끝이면 null 이 리턴된다
                while ((line = rdr.ReadLine()) != null)
                {
                    string[] student = line.Split(',');

                    Student std = new Network.Student();
                    std.Name = student[0];
                    std.Kor = double.Parse(student[1]);
                    std.Eng = double.Parse(student[2]);
                    std.Mat = double.Parse(student[3]);
                    students.Add(std);
                    //Console.WriteLine(line);
                }
            }

            // StreamWriter 객체를 생성한다. 입력파라미터로 File Path나 파일스트림 사용한다.
            using (StreamWriter wr = new StreamWriter(@"StudentResult.txt"))   //Add 일경우 new StreamWriter(@"StudentResult.txt", true)
            {
                var sumData = students.Select(a => new { Name = a.Name, Sum = a.Kor + a.Eng + a.Mat, Avg = Math.Round((a.Kor + a.Eng + a.Mat) / 3, 2) }).OrderByDescending(a => a.Sum);


                foreach (var item in sumData)
                {
                    wr.WriteLine(item.Name + "," + item.Sum + "," + item.Avg);
                }
                
            }
        }

        public void GetDir()
        {
            string[] filePaths = Directory.GetFiles(@"C:\Users\hccho\Documents\hccho\hccho\Network");  //해당 Dir
            //string[] filePaths = Directory.GetFiles(@"C:\Users\hccho\Documents\hccho\hccho\Network", "*.*", SearchOption.AllDirectories);

            foreach (var item in filePaths)
            {
                Console.WriteLine(item);
            }
            //Console.ReadKey();
        }

        public bool IsValidEmail(string email)
        {
            bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            return valid;
        }

        public bool IsValidPhone(string phone)
        {
            bool valid = Regex.IsMatch(phone, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            return valid;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public double Kor { get; set; }
        public double Eng { get; set; }
        public double Mat { get; set; }
    }
}
