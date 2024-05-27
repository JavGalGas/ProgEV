using System.Security.Cryptography;

namespace ndupcopy
{
    public class FilePath
    {
        private string _path;
        private string _base64Hash;
        public bool unique;

        public string Base64Hash => _base64Hash;
        public string File_path => _path;

        public FilePath(string path)
        {
            _path = path;
            unique = true;
            _base64Hash = CalculateHash();
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