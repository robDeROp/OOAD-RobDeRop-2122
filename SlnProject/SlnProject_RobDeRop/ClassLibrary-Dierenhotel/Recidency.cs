using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.MobileControls;
using System.Windows.Media.Imaging;
using System.IO;
namespace ClassLibrary_Dierenhotel
{
    public class Recidency
    {
        private static string connString = ConfigurationManager.AppSettings["connString"];
        public int ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Remarks { get; set; }
        public int Package_ID { get; set; }
        public string Package { get; set; }
        public int Pet_ID { get; set; }
        public string Pet { get; set; }
        public string Status { get; set; }
        public List<int> Options { get; set; }
        static public List<Recidency> GetAllRecidencies()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT R.[id],R.[startdate],R.[enddate],R.[remarks],R.[package_id], P.[name] as packageName,R.[pet_id], D.[name] as petName, confirmed FROM [DierenhotelDB].[dbo].[Residency] R INNER JOIN [DierenhotelDB].[dbo].Package P ON P.[id] = R.package_id INNER JOIN [DierenhotelDB].[dbo].[Pet] D ON D.id = R.pet_id ", conn);
                SqlDataReader reader = comm.ExecuteReader();
                List<Recidency> recidenies = new List<Recidency>();
                while (reader.Read())
                {
                    recidenies.Add(new Recidency() { ID = Convert.ToInt32(reader["id"]), StartDate = reader["startdate"].ToString(), EndDate = reader["enddate"].ToString(), Remarks = reader["remarks"].ToString(), Package_ID = int.Parse(reader["package_id"].ToString()), Package = reader["packageName"].ToString(), Pet_ID = int.Parse(reader["pet_id"].ToString()), Pet = reader["petName"].ToString(), Status = reader["confirmed"].ToString() });
                }
                return recidenies;
            }
        }
        static public List<Recidency> GetUserHistoryRecidencies(int UID)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT R.[id],R.[startdate],R.[enddate],R.[remarks],R.[package_id], P.[name] as packageName,R.[pet_id], D.[name] as petName, confirmed FROM [DierenhotelDB].[dbo].[Residency] R INNER JOIN [DierenhotelDB].[dbo].Package P ON P.[id] = R.package_id INNER JOIN [DierenhotelDB].[dbo].[Pet] D ON D.id = R.pet_id WHERE D.user_id = @par1", conn);
                comm.Parameters.AddWithValue("@par1", UID);
                SqlDataReader reader = comm.ExecuteReader();
                List<Recidency> recidenies = new List<Recidency>();
                while (reader.Read())
                {
                    recidenies.Add(new Recidency() { ID = Convert.ToInt32(reader["id"]), StartDate = reader["startdate"].ToString(), EndDate = reader["enddate"].ToString(), Remarks = reader["remarks"].ToString(), Package_ID = int.Parse(reader["package_id"].ToString()), Package = reader["packageName"].ToString(), Pet_ID = int.Parse(reader["pet_id"].ToString()), Pet = reader["petName"].ToString(), Status = reader["confirmed"].ToString() });
                }
                return recidenies;
            }
        }
        static public List<int> getOptionsByID (int ID)
        {
            List<int> options = new List<int>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT option_id FROM [DierenhotelDB].[dbo].[ResidencyOption] WHERE residency_id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", ID);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    options.Add(int.Parse(reader["option_id"].ToString()));
                }
            }
            return options;
        }
        static public void UpdateRecidency(Recidency r)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("UPDATE [DierenhotelDB].[dbo].[Residency] SET startdate = @par2, enddate= @par3, remarks = @par4, package_id = @par5, pet_id = @par6, confirmed = 0 WHERE id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", r.ID);
                comm.Parameters.AddWithValue("@par2", r.StartDate);
                comm.Parameters.AddWithValue("@par3", r.EndDate);
                comm.Parameters.AddWithValue("@par4", r.Remarks);
                comm.Parameters.AddWithValue("@par5", r.Package_ID);
                comm.Parameters.AddWithValue("@par6", r.Pet_ID);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        static public void AcceptDenyRecidency(Recidency r)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("UPDATE [DierenhotelDB].[dbo].[Residency] SET confirmed = @par2 WHERE id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", r.ID);
                comm.Parameters.AddWithValue("@par2", r.Status);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        //Deleting a user
        static public void DeleteRecidency(Recidency r)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM [DierenhotelDB].[dbo].[Residency] WHERE id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", r.ID);
                SqlDataReader reader = comm.ExecuteReader();

            }
        }
        static public List<BitmapImage> GetResImage(int r_id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                List<BitmapImage> img = new List<BitmapImage>();
                SqlCommand comm = new SqlCommand("Select data FROM Photo Where residency_id = @par1", conn);
                comm.Parameters.AddWithValue("@par1", r_id);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = new System.IO.MemoryStream((byte[])reader["data"]);
                    image.EndInit();
                    img.Add(image);
                }
                return img;
            }
        }
        static public void CreateResidency(Recidency r)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO [DierenhotelDB].[dbo].[Residency] (startdate, enddate, remarks, package_id, pet_id, confirmed) VALUES(@par1,@par2,@par3,@par4,@par5,@par6);", conn);
                comm.Parameters.AddWithValue("@par1", r.StartDate);
                comm.Parameters.AddWithValue("@par2", r.EndDate);
                comm.Parameters.AddWithValue("@par3", r.Remarks);
                comm.Parameters.AddWithValue("@par4", r.Package_ID);
                comm.Parameters.AddWithValue("@par5", r.Pet_ID);
                comm.Parameters.AddWithValue("@par6", r.Status);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        static public int GetIDResidency(Recidency r)
        {
            int RID = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string t = $"SELECT id FROM [DierenhotelDB].[dbo].[Residency] WHERE startdate = '{r.StartDate}' AND enddate = '{r.EndDate}' AND package_id = {r.Package_ID}  AND pet_id = {r.Pet_ID};";

                SqlCommand comm = new SqlCommand(t, conn);
                //comm.Parameters.AddWithValue("@par1", r.StartDate.ToString());
                //comm.Parameters.AddWithValue("@par2", r.EndDate.ToString());
                //comm.Parameters.AddWithValue("@par3", r.Package_ID);
                //comm.Parameters.AddWithValue("@par4", r.Pet_ID);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                RID = int.Parse(reader["id"].ToString());
            }
            return RID;
        }
        //Get Verblijven
        static public List<string> GetPackages(string PetName)//Gefilterd op pet Type
        {
            List<string> packeges = new List<string>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT P.name FROM [DierenhotelDB].[dbo].[Package] P INNER JOIN [DierenhotelDB].[dbo].[Pet] D ON D.[type_name] = P.pettype_name WHERE D.name = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", PetName);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    packeges.Add(reader["name"].ToString());
                }
            }
            return packeges;
        }
        //Get Verblijven
        static public int getUserIDByRecidency(int RID)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                int U = 0;
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT U.id FROM [DierenhotelDB].[dbo].[User] U INNER JOIN [DierenhotelDB].[dbo].[Pet] P ON P.user_id = U.id INNER JOIN [DierenhotelDB].[dbo].[Residency] R ON R.pet_id = P.id WHERE R.id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", RID);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                U = int.Parse(reader["id"].ToString());
                return U;
            }
        }

        // Recidency aanvragen
        static public void VerblijfAanvragen(Recidency r)
        {
            CreateResidency(r);
            int RID = GetIDResidency(r);
            foreach(int OID in r.Options)
            {
                ResidencyOption(RID, OID);
            }


        }

        static public void ResidencyOption (int RID, int OID)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO [DierenhotelDB].[dbo].[ResidencyOption] (residency_id, option_id) VALUES(@par1,@par2);", conn);
                comm.Parameters.AddWithValue("@par1", RID);
                comm.Parameters.AddWithValue("@par2", OID);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        static public void PackageOption(int PID, int OID)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO [DierenhotelDB].[dbo].[PackageOption] (package_id, option_id) VALUES(@par1,@par2);", conn);
                comm.Parameters.AddWithValue("@par1", PID);
                comm.Parameters.AddWithValue("@par2", OID);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        static public double PackagePrice(string Name)
        {
            double price = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT priceperday FROM [DierenhotelDB].[dbo].[Package] WHERE name = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", Name);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                price = double.Parse(reader["priceperday"].ToString());
                return price;
            }
        }
    }
}
