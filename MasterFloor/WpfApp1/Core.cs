using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Core
    {
        private static Data.MasterFloorEntities _context;

        public static Data.MasterFloorEntities GetContext() 
        { 
            if (_context == null )
            {
                _context = new Data.MasterFloorEntities();
            }
            return _context; 
        }
    }
}
