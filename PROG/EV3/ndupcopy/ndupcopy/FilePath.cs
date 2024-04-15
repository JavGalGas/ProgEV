namespace ndupcopy
{
    public class FilePath
    {
        private string _path;
        public bool IsDuplicate;

        public string Path => _path;

        public FilePath(string path)
        {
            _path = path;
            IsDuplicate = false;
        }
    }
}