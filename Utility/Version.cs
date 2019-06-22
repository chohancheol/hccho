using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    class VersionSort
    {
        public static void VSMain()
        {
            List<Version> versions = new List<Utility.Version>();

            Version v1 = new Version { A = 2, B = 10, C = 4, D = 1 };
            Version v2 = new Version { A = 1, B = 10, C = 4, D = 1 };
            Version v3 = new Version { A = 3, B = 10, C = 4, D = 1 };
            Version v4 = new Version { A = 1, B = 9, C = 4, D = 1 };
            Version v5 = new Version { A = 1, B = 10, C = 2, D = 1 };

            versions.Add(v1);
            versions.Add(v2);
            versions.Add(v3);
            versions.Add(v4);
            versions.Add(v5);

            List<Version> sversions = (from ver in versions orderby ver.A, ver.B, ver.C, ver.D select ver).ToList();
        }
    }
    class Version
    {
        public int A;
        public int B;
        public int C;
        public int D;
    }
}
