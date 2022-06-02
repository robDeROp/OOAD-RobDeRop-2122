using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.MobileControls;
using System.Windows.Media.Imaging;

namespace ClassLibrary_Dierenhotel
{
    public class Pet
    {
        private static string connString = ConfigurationManager.AppSettings["connString"];

        public int ID { get; set; }

        public string Name { get; set; }
        public string Remarks { get; set; }
        public string Sex { get; set; }
        public string Size { get; set; }
        public string Age { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        static public List<Pet> GetAllPets()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT P.[id], P.[name], P.[remarks], P.[sex], P.[size], P.[age], U.[firstname], U.[lastname], P.[type_name] as Type FROM[DierenhotelDB].[dbo].[Pet] P INNER JOIN[DierenhotelDB].[dbo].[User] U ON U.id = P.[user_id]", conn);
                SqlDataReader reader = comm.ExecuteReader();
                List<Pet> pets = new List<Pet>();
                while (reader.Read())
                {
                    pets.Add(new Pet() { ID = Convert.ToInt32(reader["id"]), Name = reader["name"].ToString(), Remarks = reader["remarks"].ToString(), Sex = reader["sex"].ToString(), Size = reader["size"].ToString(), Age = reader["age"].ToString(), Owner = reader["firstname"].ToString() + " " + reader["lastname"].ToString(), Type = reader["Type"].ToString() });
                }
                return pets;
            }
        }
        static public List<BitmapImage> GetPetImage(Pet p)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                List<BitmapImage> img = new List<BitmapImage>();
                SqlCommand comm = new SqlCommand("Select data FROM Photo Where pet_id = @par1", conn);
                comm.Parameters.AddWithValue("@par1", p.ID);
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
    }
}
