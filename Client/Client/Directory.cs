
using System.Collections.Generic;
using System.IO;

namespace Client
{
    class Directory
    {
        public Directory()
        {
        }

        public Directory(IEnumerable<FileSystemInfo> directoryInfo, string root)
        {
            DirectoryInfo = directoryInfo;
            Root = root;
        }

        public IEnumerable<FileSystemInfo> DirectoryInfo { get; set; }

        public string Root { get; set; }
    }
}
