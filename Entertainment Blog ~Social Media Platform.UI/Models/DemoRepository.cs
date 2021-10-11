using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog__Social_Media_Platform.UI.Models
{
    public static class DemoRepository
    {
        public static List<Demo> _Demos = new List<Demo>();
        public static List<Demo> Demos
        {
            get
            {
                return _Demos;
            }
        }
        public static void AddDemo(Demo demo)
        {
            _Demos.Add(demo);
        }
    }
}
