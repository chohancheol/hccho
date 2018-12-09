using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class _2_class
    {
        // ref 정의
        static double GetData(ref int a, ref double b)
        { return ++a * ++b; }

        // out 정의
        static bool GetData(int a, int b, out int c, out int d)
        {
            c = a + b;
            d = a - b;
            return true;
        }

        public void reference()
        {
            // ref 사용. 초기화 필요.
            int x = 1;
            double y = 1.0;
            double ret = GetData(ref x, ref y);

            // out 사용. 초기화 불필요.
            int c, d;
            bool bret = GetData(10, 20, out c, out d);

            Console.WriteLine(" x : {0}, y : {1}, c: {2}, d: {3}", x, y, c, d);
        }
    }


    public class MyCustomer
    {
        // 필드
        private string name;
        private int age;

        // 이벤트 
        public event EventHandler NameChanged;

        // 생성자 (Constructor)
        public MyCustomer()
        {
            name = string.Empty;
            age = -1;
        }

        // 속성
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    if (NameChanged != null)
                    {
                        NameChanged(this, EventArgs.Empty);
                    }
                }
            }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        // 메서드
        public string GetCustomerData()
        {
            string data = string.Format("Name: {0} (Age: {1})",
                        this.Name, this.Age);
            return data;
        }
    }

}
