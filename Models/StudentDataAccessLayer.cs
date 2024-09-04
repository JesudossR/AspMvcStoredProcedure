using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace MVCCoreDemo.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = "Server=localhost;Database=user;User=root;Password='';";

        // string connectionString = "Your Connection String here";

        // To View all Student details
        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> studList = new List<Student>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spGetAllStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student stud = new Student();

                    stud.StudId = Convert.ToInt32(rdr["StudID"]);
                    stud.Name = rdr["Name"].ToString();
                    stud.Gender = rdr["Gender"].ToString();
                    stud.Department = rdr["Department"].ToString();
                    stud.City = rdr["City"].ToString();

                    studList.Add(stud);
                }
                con.Close();
            }
            return studList;
        }

        // To Add new student record
        public void AddStudent(Student student)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@P_Name", student.Name);
                cmd.Parameters.AddWithValue("@P_Gender", student.Gender);
                cmd.Parameters.AddWithValue("@P_Department", student.Department);
                cmd.Parameters.AddWithValue("@P_City", student.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // To Update the records of an individual student
        public void UpdateStudent(Student student)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@P_StudId", student.StudId);
                cmd.Parameters.AddWithValue("@P_Name", student.Name);
                cmd.Parameters.AddWithValue("@P_Gender", student.Gender);
                cmd.Parameters.AddWithValue("@P_Department", student.Department);
                cmd.Parameters.AddWithValue("@P_City", student.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Get the details of an individual student
        public Student GetStudentData(int? id)
        {
            Student student = new Student();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblStudent WHERE StudID = @P_StudId";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@P_StudId", id);

                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    student.StudId = Convert.ToInt32(rdr["StudID"]);
                    student.Name = rdr["Name"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    student.Department = rdr["Department"].ToString();
                    student.City = rdr["City"].ToString();
                }
                con.Close();
            }
            return student;
        }

        // To Delete the record of a particular student
        public void DeleteStudent(int? id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spDeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@P_StudId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}