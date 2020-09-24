using BitPazari.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPazari.Service.Tools
{
    class SingletonContext
    {
        //Singleton Desing Pattern
        private static DbContext _instance;
        public static DbContext DbInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProjectContext();
                }
                return _instance;
            }
            
        
        }
    }
}
