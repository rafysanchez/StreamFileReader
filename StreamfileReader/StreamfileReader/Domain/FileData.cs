using System;
using System.Collections.Generic;
using System.Text;

namespace StreamfileReader.Domain
{
    public sealed class FileData
    {
        public string FullName { get; set; }

        public HashSet<string> Lines { get; set; }
    }
}
