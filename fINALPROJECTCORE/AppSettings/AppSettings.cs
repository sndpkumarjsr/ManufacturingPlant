using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fINALPROJECTCORE.AppSettings
{
    public class AppSettings
    {
        public static ConnnectionString ConnnectionString { get; set; }=new ConnnectionString();    
    }
    public class ConnnectionString
    {
        public string DevOps { get; set; }
        public string InetData { get; set; }
        public string TransregData { get; set; }
    }
}
