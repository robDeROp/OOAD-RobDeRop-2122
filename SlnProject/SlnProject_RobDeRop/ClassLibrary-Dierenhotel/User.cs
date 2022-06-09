using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Dierenhotel
{

    public class User
    {
        private static string connString = ConfigurationManager.AppSettings["connString"];

        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Login { get; set; }
        public string CreationDate { get; set; }
        public string Password { get; set; }
        public string Function { get; set; }
        static public bool AdminLogin(string login, string password)//login Sql Query
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT count([id]) as C FROM [DierenhotelDB].[dbo].[User] WHERE login = @par1 AND password = @par2 AND role = @par3", conn);
                comm.Parameters.AddWithValue("@par1", login);
                comm.Parameters.AddWithValue("@par2", password);
                comm.Parameters.AddWithValue("@par3", "admin");
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                int c = Convert.ToInt32(reader["C"]);
                if (c > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        static public bool UserLogin(string login, string password)//login Sql Query
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT count([id]) as C FROM [DierenhotelDB].[dbo].[User] WHERE login = @par1 AND password = @par2", conn);
                comm.Parameters.AddWithValue("@par1", login);
                comm.Parameters.AddWithValue("@par2", password);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                int c = Convert.ToInt32(reader["C"]);
                if (c > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        //static public bool UserLogin(string login, string password)//login Sql Query
        //{
        //    bool result = false;
        //    using (SqlConnection conn = new SqlConnection(connString))
        //    {
        //        conn.Open();
        //        SqlCommand comm = new SqlCommand("SELECT count([id]) as C FROM [DierenhotelDB].[dbo].[User] WHERE login = @par1 AND password = @par2", conn);
        //        comm.Parameters.AddWithValue("@par1", login);
        //        comm.Parameters.AddWithValue("@par2", password);
        //        SqlDataReader reader = comm.ExecuteReader();
        //        reader.Read();
        //        int c = Convert.ToInt32(reader["C"]);
        //        if (c > 0)
        //        {
        //            result = true;
        //        }
        //        else
        //        {
        //            result = false;
        //        }
        //    }
        //    return result;
        //}
        static public int GetUserID(string login, string password)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT id FROM [DierenhotelDB].[dbo].[User] WHERE login = @par1 AND password = @par2", conn);
                comm.Parameters.AddWithValue("@par1", login);
                comm.Parameters.AddWithValue("@par2", password);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                result = Convert.ToInt32(reader["id"]);

            }
            return result;
        }

        //Main Window Dashboard, get all user data
        static public List<User> GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM [DierenhotelDB].[dbo].[User]", conn);
                SqlDataReader reader = comm.ExecuteReader();
                List<User> Data = new List<User>();
                while (reader.Read())
                {
                    Data.Add(new User() { ID = Convert.ToInt32(reader["id"]), Login = reader["login"].ToString(), Fname = reader["firstname"].ToString(), Lname = reader["lastname"].ToString(), Function = reader["role"].ToString(), CreationDate = reader["createdate"].ToString(), Password = reader["password"].ToString() });
                }
                return Data;
            }
        }
        static public void UpdateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("UPDATE [DierenhotelDB].[dbo].[User] SET login = @par2, password = @par3, firstname = @par4, lastname = @par5, role = @par6 WHERE id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", user.ID);
                comm.Parameters.AddWithValue("@par2", user.Login);
                comm.Parameters.AddWithValue("@par3", user.Password);
                comm.Parameters.AddWithValue("@par4", user.Fname);
                comm.Parameters.AddWithValue("@par5", user.Lname);
                comm.Parameters.AddWithValue("@par6", user.Function);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        //Creating a new user
        static public void CreateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO [DierenhotelDB].[dbo].[User] (login, password, firstname, lastname, createdate, role) VALUES(@par1,@par2,@par3,@par4,@par5,@par6);", conn);
                comm.Parameters.AddWithValue("@par1", user.Login);
                comm.Parameters.AddWithValue("@par2", user.Password);
                comm.Parameters.AddWithValue("@par3", user.Fname);
                comm.Parameters.AddWithValue("@par4", user.Lname);
                comm.Parameters.AddWithValue("@par5", user.CreationDate);
                comm.Parameters.AddWithValue("@par6", user.Function);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        //Deleting a user
        static public void DeleteUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM [DierenhotelDB].[dbo].[User] WHERE id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", user.ID);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
    }
}
