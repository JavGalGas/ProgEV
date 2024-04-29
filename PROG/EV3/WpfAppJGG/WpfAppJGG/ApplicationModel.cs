using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppJGG
{
    public class ApplicationModel
    {
        public static ApplicationModel Instance { get; } = new ApplicationModel();

        public void Run()
        {

        }
            
        private ApplicationModel() 
        {
            
        }
    }
}
