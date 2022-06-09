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
        public string Owner_ID { get; set; }

        public string Owner { get; set; }
        static public List<Pet> GetAllPets()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT P.[id], P.[name], P.[remarks], P.[sex], P.[size], P.[age], U.[id] as PID, U.[firstname], U.[lastname], P.[id] as TID, P.[type_name] as Type FROM[DierenhotelDB].[dbo].[Pet] P INNER JOIN[DierenhotelDB].[dbo].[User] U ON U.id = P.[user_id]", conn);
                SqlDataReader reader = comm.ExecuteReader();
                List<Pet> pets = new List<Pet>();
                while (reader.Read())
                {
                    pets.Add(new Pet() { 
                        ID = Convert.ToInt32(reader["id"]), 
                        Name = reader["name"].ToString(), 
                        Remarks = reader["remarks"].ToString(), 
                        Sex = reader["sex"].ToString(), 
                        Size = reader["size"].ToString(), 
                        Age = reader["age"].ToString(), 
                        Owner_ID = reader["PID"].ToString(), 
                        Owner = reader["firstname"].ToString() + " " + reader["lastname"].ToString(), 
                        Type = reader["Type"].ToString() });
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
        static public void UploadImage(string i, Pet p, int r)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                byte[] imageData = File.ReadAllBytes(i);
                using (SqlCommand comm = new SqlCommand("INSERT INTO [DierenhotelDB].[dbo].[Photo] (data, pet_id, residency_id) VALUES(@par1, @par2, @par3);", conn))
                {
                    comm.Parameters.AddWithValue("@par1", imageData);
                    comm.Parameters.AddWithValue("@par2", p.ID);
                    comm.Parameters.AddWithValue("@par3", r);
                    comm.ExecuteNonQuery();
                }
            }
        }

        static public void UpdatePet(Pet pet)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("UPDATE [DierenhotelDB].[dbo].[Pet] SET name = @par2, remarks= @par3, sex = @par4, size = @par5, age = @par6, user_id = @par7, type_name = @par8 WHERE id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", pet.ID);
                comm.Parameters.AddWithValue("@par2", pet.Name);
                comm.Parameters.AddWithValue("@par3", pet.Remarks);
                comm.Parameters.AddWithValue("@par4", int.Parse(pet.Sex));
                comm.Parameters.AddWithValue("@par5", int.Parse(pet.Size));
                comm.Parameters.AddWithValue("@par6", int.Parse(pet.Age));
                comm.Parameters.AddWithValue("@par7", int.Parse(pet.Owner_ID));
                comm.Parameters.AddWithValue("@par8", pet.Type);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        //Creating a new user
        static public void CreatePet(Pet pet)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO [DierenhotelDB].[dbo].[Pet] (name, remarks, sex, size, age, user_id, type_name) VALUES(@par1,@par2,@par3,@par4,@par5,@par6,@par7);", conn);
                comm.Parameters.AddWithValue("@par1", pet.Name);
                comm.Parameters.AddWithValue("@par2", pet.Remarks);
                comm.Parameters.AddWithValue("@par3", pet.Sex);
                comm.Parameters.AddWithValue("@par4", pet.Size);
                comm.Parameters.AddWithValue("@par5", pet.Age);
                comm.Parameters.AddWithValue("@par6", pet.Owner_ID);
                comm.Parameters.AddWithValue("@par7", pet.Type);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        //Deleting a user
        static public void DeletePet(Pet pet)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM [DierenhotelDB].[dbo].[Pet] WHERE id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", pet.ID);
                SqlDataReader reader = comm.ExecuteReader();
            }
        }
        //Get pet ID by Name
        static public int GetPetId(string name, string ownerID)
        {
            int PetID = -1;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT id FROM [DierenhotelDB].[dbo].[Pet] WHERE name = @par1 AND user_id = @par2;", conn);
                comm.Parameters.AddWithValue("@par1", name);
                comm.Parameters.AddWithValue("@par2", ownerID);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                PetID = int.Parse(reader["id"].ToString()); 
            }
            return PetID;
        }
        // Pet names by user
        static public List<string> GetPetNames (int ID)
        {
            List<string> names = new List<string>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT name FROM[DierenhotelDB].[dbo].[Pet] WHERE user_id = @par1;", conn);
                comm.Parameters.AddWithValue("@par1", ID);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    names.Add(reader["name"].ToString());
                }
            }
            return names;
        }
    }
}
