using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Prihlasovanie
{
    public class DataHandler
    {
        public List<User> users = new List<User>();
        public static string nameFile = "userData.xml";

        public void DataLoad()
        {
            try
            {
                XmlSerializer xmlDeser = new XmlSerializer(users.GetType());
                using (StreamReader sr = new StreamReader(nameFile))
                {
                    users = (List<User>)xmlDeser.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void SaveData()
        {
            XmlSerializer xmlSer = new XmlSerializer(users.GetType());
            using (StreamWriter sw = new StreamWriter(nameFile))
            {
                xmlSer.Serialize(sw, users);
            }
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
