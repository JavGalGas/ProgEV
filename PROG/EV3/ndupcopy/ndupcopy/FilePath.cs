using System.Security.Cryptography;

namespace ndupcopy
{
    public class FilePath
    {
        private string _path;
        public bool IsDuplicate;
        public string hash => CalculateHash();
        public int hash2 => GetHashCode();
        public string Path => _path;

        public FilePath(string path)
        {
            _path = path;
            IsDuplicate = false;
        }

        public string CalculateHash()
        {
            using (var stream = File.OpenRead(_path))
            {
                var sha = SHA256.Create();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }


    }
}