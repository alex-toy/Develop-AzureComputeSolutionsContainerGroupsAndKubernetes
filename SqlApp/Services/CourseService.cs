using MySql.Data.MySqlClient;
using SqlApp.Models;

namespace SqlApp.Services
{
    public class CourseService
    {
        private MySqlConnection GetConnection(string _connection_string)
        {
            return new MySqlConnection(_connection_string);
        }

        public IEnumerable<Course> GetCourses(string _connection_string)
        {
            List<Course> _lst = new List<Course>();
            string _statement = "SELECT CourseID,CourseName,rating from Course";
            MySqlConnection _connection = GetConnection(_connection_string);

            _connection.Open();

            MySqlCommand _sqlcommand = new MySqlCommand(_statement, _connection);

            using (MySqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        CourseID = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };

                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }
    }
}
