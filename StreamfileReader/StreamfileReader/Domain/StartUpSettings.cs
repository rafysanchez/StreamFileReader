using System;
using System.Collections.Generic;
using System.Text;

namespace StreamfileReader.Domain {
    public sealed class StartUpSettings {

        public string InComingDirectory { get; set; }

        public string SearchPattern { get; set; }
    }
}
