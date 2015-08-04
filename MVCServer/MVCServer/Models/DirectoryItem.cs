using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MVCServer.Models
{
    [DataContract]
    public class DirectoryItem
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Fullname { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Size { get; set; }


        public DirectoryItem(FileSystemInfo fsi)
        {
            Name = fsi.Name;
            Fullname = fsi.FullName;
            if (fsi is DirectoryInfo)
            {
                Type = "Directory";
                Size = string.Empty;
            }
            else
            {
                Type = "File";
                Size = (((FileInfo) fsi).Length/1024.0).ToString("0.#")+" KB";
            }
        }

        public static IEnumerable<DirectoryItem> DirectoryContents(string path)
        {
            return new DirectoryInfo(path).EnumerateFileSystemInfos().Select(fsi => new DirectoryItem(fsi));
        }
    }
}