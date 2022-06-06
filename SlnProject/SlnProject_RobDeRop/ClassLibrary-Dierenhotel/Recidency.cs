using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace ClassLibrary_Dierenhotel
{
    public class Recidency
    {
        private static string connString = ConfigurationManager.AppSettings["connString"];
        public int ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Remarks { get; set; }
        public string Package_ID { get; set; }
        public string Package { get; set; }
        public string Pet_ID { get; set; }
        public string Pet { get; set; }
        static public List<Recidency> GetAllRecidencies()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT R.[id],R.[startdate],R.[enddate],R.[remarks],R.[package_id], P.[name] as packageName,R.[pet_id], D.[name] as petName FROM [DierenhotelDB].[dbo].[Residency] R INNER JOIN [DierenhotelDB].[dbo].Package P ON P.[id] = R.package_id INNER JOIN [DierenhotelDB].[dbo].[Pet] D ON D.id = R.pet_id ", conn);
                SqlDataReader reader = comm.ExecuteReader();
                List<Recidency> recidenies = new List<Recidency>();
                while (reader.Read())
                {
                    recidenies.Add(new Recidency() { ID = Convert.ToInt32(reader["id"]), StartDate = reader["startdate"].ToString(), EndDate = reader["enddate"].ToString(), Remarks = reader["remarks"].ToString(), Package_ID = reader["package_id"].ToString(), Package = reader["packageName"].ToString() + ")", Pet_ID = reader["pet_id"].ToString(), Pet = reader["petName"].ToString()});
                }
                return recidenies;
            }
        }
        static public void UpdateRecidency(Recidency r)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("UPDATE [DierenhotelDB].[dbo].[Recidency] SET startdate = @par2, enddate= @par3, remarks = @par4, package_id = @par5, pet_id = @par6 WHERE id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", r.ID);
                comm.Parameters.AddWithValue("@par2", r.StartDate);
                comm.Parameters.AddWithValue("@par3", r.EndDate);
                comm.Parameters.AddWithValue("@par4", r.Remarks);
                comm.Parameters.AddWithValue("@par5", r.Package_ID);
                comm.Parameters.AddWithValue("@par6", r.Pet_ID);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        //Creating a new user
        static public void CreateRecidency(Recidency r)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO [DierenhotelDB].[dbo].[Recidency] (startdate, enddate, remarks, package_id, pet_id) VALUES(@par1,@par2,@par3,@par4,@par5);", conn);
                comm.Parameters.AddWithValue("@par1", r.StartDate);
                comm.Parameters.AddWithValue("@par2", r.EndDate);
                comm.Parameters.AddWithValue("@par3", r.Remarks);
                comm.Parameters.AddWithValue("@par4", r.Package_ID);
                comm.Parameters.AddWithValue("@par5", r.Pet_ID);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        //Deleting a user
        static public void DeleteRecidency(Recidency r)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM [DierenhotelDB].[dbo].[Recidency] WHERE id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", r.ID);
                SqlDataReader reader = comm.ExecuteReader();

            }
        }
