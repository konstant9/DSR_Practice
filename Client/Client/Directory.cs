
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Client
{
    class Directory
    {
        public Directory()
        {
        }

        public Directory(IEnumerable<DirectoryItem> directoryInfo, string root)
        {
            DirectoryInfo = directoryInfo;
            Root = root;
        }

        public Directory(DriveInfo[] drives)
        {
            DirectoryInfo = drives.Select(dr => new DirectoryItem(dr.Name, dr.Name, "Drive", string.Empty));
            Root = string.Empty;
        }

        public IEnumerable<DirectoryItem> DirectoryInfo { get; set; }

        public string Root { get; set; }
    }
}
