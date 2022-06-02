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
        public string Package { get; set; }
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
                    recidenies.Add(new Recidency() { ID = Convert.ToInt32(reader["id"]), StartDate = reader["startdate"].ToString(), EndDate = reader["enddate"].ToString(), Remarks = reader["remarks"].ToString(), Package = reader["package_id"].ToString() + " (" + reader["packageName"].ToString() + ")", Pet = reader["pet_id"].ToString() + " (" + reader["petName"].ToString() + ")" });
                }
                return recidenies;
            }
        }
    }
}
