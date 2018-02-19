using System;
using CalcTableSum;

namespace CalcService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CalcListener calcListener = new CalcListener();
            calcListener.ExecuteNonQuery(@"
                use testdb

                IF OBJECT_ID('dbo.Numbers', 'U') IS NOT NULL
                    DROP TABLE dbo.Numbers
                CREATE TABLE dbo.Numbers
                (
                    Name [NVARCHAR](50) NOT NULL,
                    Value int NOT NULL
                );
            ");

            calcListener.Init();
            calcListener.Start();

            calcListener.ExecuteNonQuery(@"
                use testdb
                insert into numbers values ('a', 1)
                insert into numbers values ('b', 2)
                update numbers set value=3 where name='b'
                delete from numbers where name='a'
            ");
            Console.WriteLine("Press Enter to quit this app.");
            string test = Console.ReadLine();

            calcListener.Stop();
        }
    }
}
