using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
        public class DirectoryItem
        {
            public string Name { get; set; }

            public string Fullname { get; set; }

            public string Type { get; set; }

            public string Size { get; set; }

            public DirectoryItem(string name, string fullname, string type, string size)
            {
                Name = name;
                Fullname = fullname;
                Type = type;
                Size = size;
            }
        }
}
