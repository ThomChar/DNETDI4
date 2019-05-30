using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class RequeteBD
    {

        private SQLiteConnection sql_con;
        private string dataBasePath;
        private MagasinDAO magasin;

        public RequeteBD()
        {
        }

        public RequeteBD(SQLiteConnection sql_con, string dataBasePath, MagasinDAO magasin)
        {
            this.sql_con = sql_con;
            this.dataBasePath = dataBasePath;
            this.magasin = magasin;
        }


    }
}
