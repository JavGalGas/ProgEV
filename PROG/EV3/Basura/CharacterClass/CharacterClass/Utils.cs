using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public static class Utils
    {
        public static string ImageToBase64(string imagePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagePath);
            string base64Image = Convert.ToBase64String(imageArray);
            return base64Image;
        }

        public static void Base64ToImage(string base64String, string outputPath)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(outputPath, imageBytes);
        }

    }
}
