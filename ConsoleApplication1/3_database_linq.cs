using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _3_database
    {
        public void DB_Update()
        {

            // Sql 연결정보(서버:127.0.0.1, 포트:3535, 아이디:sa, 비밀번호 : password, db : member)
            string connectionString = "server = 127.0.0.1,3535; uid = sa; pwd = password; database = member;";
            // Sql 새연결정보 생성
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;
            sqlComm.CommandText = "insert into tbl_member (id,name,addr) values (@param1,@param2,param3)";
            //sqlComm.CommandText = "update tbl_member set addr=@param3 where id=@param1 and name=param2";
            //sqlComm.CommandText = "delete tbl_member where id=@param1 and name=param2 and addr=@param3";
            sqlComm.Parameters.AddWithValue("@param1", "abc");
            sqlComm.Parameters.AddWithValue("@param2", "홍길동");
            sqlComm.Parameters.AddWithValue("@param3", "서울");
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();


        }

        public void DB_Select()
        {

            // Sql 연결정보(서버:127.0.0.1, 포트:3535, 아이디:sa, 비밀번호 : password, db : member)
            //connectionString="Persist Security Info=False;Integrated Security=false;database=EZUMS_HMI_1;server=127.0.0.1,1433;User ID=sa;Password=a123456789" providerName="System.Data.SqlClient"
            string connectionString = "server = 127.0.0.1,3535; uid = sa; pwd = password; database = member;";
            // Sql 새연결정보 생성
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;
            sqlComm.CommandText = "insert into tbl_member (id,name,addr) values (@param1,@param2,param3)";
            //sqlComm.CommandText = "update tbl_member set addr=@param3 where id=@param1 and name=param2";
            //sqlComm.CommandText = "delete tbl_member where id=@param1 and name=param2 and addr=@param3";
            sqlComm.Parameters.AddWithValue("@param1", "abc");
            sqlComm.Parameters.AddWithValue("@param2", "홍길동");
            sqlComm.Parameters.AddWithValue("@param3", "서울");
            sqlConn.Open();

            SqlDataReader rdr0 = sqlComm.ExecuteReader();

            // 다음 레코드 계속 가져와서 루핑
            while (rdr0.Read())
            {
                // C# 인덱서를 사용하여
                // 필드 데이타 엑세스
                string s = rdr0["Name"] as string;
            }
            // 사용후 닫음
            rdr0.Close();

            sqlConn.Close();



            SqlConnection conn0 = new SqlConnection(connectionString);
            conn0.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Tab1", conn0);

            // DataSet에 테이블 데이타를 넣음
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Tab1");

            conn0.Close();

            //Paremter 추가
            SqlDataAdapter da;
            da = new SqlDataAdapter("SELECT * FROM annotations WHERE annotation LIKE '%@search%'", connectionString);
            da.SelectCommand.Parameters.AddWithValue("@search", "ㅁㅁ");
            var dt = new DataTable();
            da.Fill(dt);
            

            // using 사용
            string strConn = "Data Source=192.168.1.10,1433;Initial Catalog=school;User ID=test;Password=1234;";
            String sql = "select top 5 * from student";
            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            String name = rdr["name"] as string;
                            String kor = rdr[1] as String;
                            String eng = rdr[2] as String;
                            String math = rdr[3] as String;
                            Console.WriteLine(" {0}, {1}, {2}, {3}", name, kor, eng, math);
                        }
                    }

                    //또는
                    DataTable dataTable = new DataTable();
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        dataTable.Load(dataReader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ============= exception ===============");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Linq()
        {
            //result 120
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            var result = numbers.Aggregate((a, b) => a * b);

            //result 10.5
            int[] numbers2 = { 10, 10, 11, 11 };

            var result2 = numbers2.Average();


            //ToList
            string[] names3 = { "Brenda", "Carl", "Finn" };

            List<string> result3 = names3.ToList();

            //result4 Two    
            string[] words4 = { "One", "Two", "Three" };

            var result4 = words4.ElementAt(1);


            //sorting
            List<Car> cars = new List<Car>();

            cars.Add(new Car { Name = "Super Car", HorsePower = 215 });
            cars.Add(new Car { Name = "Economy Car", HorsePower = 75 });
            cars.Add(new Car { Name = "Family Car", HorsePower = 145 });
            // Car[] cars =
            //{
            //     new Car { Name = "Super Car", HorsePower = 215 },
            //     new Car { Name = "Economy Car", HorsePower = 75 },
            //     new Car { Name = "Family Car", HorsePower = 145 },
            // };

            var result5 = cars.OrderBy(c => c.HorsePower);

            //sorting2 (Paris, Seoul, Tokyo, Athens.....)
            string[] capitals = { "Berlin", "Paris", "Madrid", "Tokyo", "London",
                          "Athens", "Beijing", "Seoul" };

            var result6 = capitals.OrderBy(c => c.Length).ThenBy(c => c);

            //where
            Person[] persons = {
                new Person { Name = "Mike", Age = 25 },
                new Person { Name = "Joe", Age = 43 },
                new Person { Name = "Nadia", Age = 31 }
            };

            var result7 = persons.Where(p => p.Age >= 30);

            int[] numbers8 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result8 = numbers.Where((n, i) => n % 3 == 0 && i >= 5);

            //All, Contains, Skip, Take, Concat

            //Distinct, Except, Intersect, Union

        }
    }

    class TestTable
    {
        string ID;

        string Value;
    }

    class Car
    {
        public string Name { get; set; }
        public int HorsePower { get; set; }
    }


    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
