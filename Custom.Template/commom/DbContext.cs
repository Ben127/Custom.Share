using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Template.Commom
{
    /// <summary>
    ///  DbContext
    /// </summary>
    public class DbContext : PetaPoco.Database
    {

        public DbContext()
            : base()
        {

        }

        public DbContext(string connectionName)
            : base(connectionName)
        {

        }




    }
}
