using System.Data.SqlClient;
using System.Diagnostics;
using WpfAppJGG;

namespace ClassLibrary1
{
    public class SQLDatabase : IDatabase
    {
        private static string _Instance = "Data Source=192.168.56.101;Initial Catalog=WPFDATABASE ;User ID=sa; Password=SqlServer123;";
        private SQLDatabase()
        {

        }

        public long AddStudent(Student student)
        {
            string insertQuery = "INSERT INTO students (nombre, edad) VALUES (@nombre, @edad)";
            using (var connection = new SqlConnection(_Instance))
            {
                connection.Open();
                using (var command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("name", student.Name);
                    command.Parameters.AddWithValue("edad", student.Age);
                    command.Parameters.AddWithValue(_Instance, student.Description);

                    int rowsAffected = command.ExecuteNonQuery();
                    var idGenerado = Convert.ToInt64(command.ExecuteScalar());
                    return idGenerado;
                }
            }
        }

        public Student? GetStudent(long id)
        {
            string selectQuery = "SELECT _id, name, age FROM STUDENTS WHERE id = @StudentId";

            using (var connection = new SqlConnection(_Instance))
            {
                connection.Open();
                using (var command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", id);
                    using (var cursor = command.ExecuteReader())
                    {
                        if (cursor.Read())
                        {
                            return new Student()
                            {
                                Id = (long)cursor["_id"],
                                Name = (string)cursor["Name"],
                                Age = (int)cursor["Age"],
                                Description = (string)cursor["Description"]
                            };
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        public Student GetStudentAt(int index)
        {
            throw new NotImplementedException();
        }

        public int GetStudentCount()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(long id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
