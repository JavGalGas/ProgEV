using System.Data.SqlClient;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        public const string conncectionString = "Data Source=192.168.56.101;Initial Catalog=WPFDATABASE ;User ID=sa; Password=SqlServer123;";
        public static void TestConnection()
        {
            //SqlConnection connection= new SqlConnection(conncectionString);
            ////...
            //connection.Open();
            //connection.Dispose();

            using (var connection2 =  new SqlConnection(conncectionString))
            {
                try
                {
                    connection2.Open();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public static void TestInsert(string name, int age)
        {
            ExecuteInsert(name, age);
        }

        public static long ExecuteInsert(string name, int age)
        {
            name = "Juan";
            age = 16;
            string insertQuery = "INSERT INTO students (nombre, edad) VALUES (@nombre, @edad)";

            using (var connection = new SqlConnection(conncectionString))
            {
                //try
                //{
                connection.Open();
                using (var command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("edad", age);

                    int rowsAffected = command.ExecuteNonQuery();
                    Debug.Assert(rowsAffected == 0);
                    //if (rowsAffected == 0)
                    //    throw new Exception("No se ha insertado nada.");
                    var idGenerado = Convert.ToInt64(command.ExecuteScalar());
                    return idGenerado;
                }

                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
            }
        }

        public static void TestSelect(string name, int age)
        {
            string studentName = "Ana";
            int studentAge = Convert.ToInt32(age);
            long id = ExecuteInsert("Juan", 16);
            string selectQuery = "SELECT _id, name, age FROM STUDENTS WHERE id = @StudentId";

            using (var connection = new SqlConnection(conncectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", id);
                    using (var cursor = command.ExecuteReader())
                    {
                        while (cursor.Read())
                        {
                            //var type = cursor.GetFieldType(0);
                            var idStudent = Convert.ToInt64(cursor.GetValue(0));
                            var nameStudent = cursor.GetString(1);
                            //var nameStudent = Convert.ToString(cursor["name"]);
                            var ageStudent = Convert.ToInt32(cursor.GetValue(2));

                            Debug.Assert(nameStudent == studentName);
                            //Debug.Assert(ageStudent == studentAge);
                        }
                    }
                }
            }
        }

        public static void ExecuteSelect(string name, int age)
        {
            string studentName = "Ana";
            int studentAge = Convert.ToInt32(age);
            long id = ExecuteInsert("Juan", 16);
            string selectQuery = "SELECT _id, name, age FROM STUDENTS WHERE id = @StudentId";

            using (var connection = new SqlConnection(conncectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", id);
                    using (var cursor = command.ExecuteReader())
                    {
                        while (cursor.Read())
                        {
                            //var type = cursor.GetFieldType(0);
                            var idStudent = Convert.ToInt64(cursor.GetValue(0));
                            var nameStudent = cursor.GetString(1);
                            //var nameStudent = Convert.ToString(cursor["name"]);
                            var ageStudent = Convert.ToInt32(cursor.GetValue(2));

                            Debug.Assert(nameStudent == studentName);
                            //Debug.Assert(ageStudent == studentAge);
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            TestConnection();
        }

        //Descargar e instalar System.Data.SqlClient
    }
}