using System.Security.Cryptography;

namespace ndupcopy
{
    public class FilePath
    {
        private string _path;
        public bool unique;

        public string Base64Hash => CalculateHash();
        public string File_path => _path;

        public FilePath(string path)
        {
            _path = path;
            unique = true;
        }

        private string CalculateHash()
        {
            using (SHA256 sha = SHA256.Create())
            using (var stream = File.OpenRead(_path))
            {
                byte[] hash = sha.ComputeHash(stream);
                return Convert.ToBase64String(hash);
            }            
        }

    }
}