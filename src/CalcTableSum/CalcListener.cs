using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CalcTableSum
{
    public class CalcListener
    {
        private const string connectionString = "Data Source=localhost,1401;User ID=SA;Password=MyNiceW8w##rd;";

        private SqlDependencyEx listener = new SqlDependencyEx(connectionString, "testdb", "numbers");

        public void Init() {
            // e.Data contains actual changed data in the XML format
            listener.TableChanged += (o, e) => { 
                IEnumerator<XElement> en = e.Data.Descendants().GetEnumerator();
                en.MoveNext(); string sqlCommand = en.Current.Name.LocalName;
                en.MoveNext(); // skip 'row'
                en.MoveNext(); string name = en.Current.Value;
                en.MoveNext(); string value = en.Current.Value;
                // foreach (var el in e.Data.Descendants()) {
                //     Console.WriteLine("{0}:{1}", el.Name, el.Value);
                //     // foreach (var attrib in el.Attributes()) { Console.WriteLine("> " + attrib.Name + " = " + attrib.Value); }
                // }
                Console.WriteLine("{0} {1}:{2}", sqlCommand, name, value);
            };
        }

        public void Start() {
            // After you call the Start method you will receive table notifications with 
            // the actual changed data in the XML format
            listener.Start();
        }
        public void Stop() {
            listener.Stop();
        }

        public void ExecuteNonQuery(string commandText)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(commandText, conn))
            {
                conn.Open();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
        }

    }
}
