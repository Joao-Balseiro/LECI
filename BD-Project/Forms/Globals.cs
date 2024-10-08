using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoEventos
{
    public static class Globals
    {
        private static string dbServer = @"tcp:mednat.ieeta.pt\SQLSERVER,8101;TrustServerCertificate=True";

        private static string dbName = "p1g6";
        private static string userName = "p1g6";
        private static string userPass = "BDg6.001#";

        public static string strConn = "Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName + "; uid = " + userName + ";" + "password = " + userPass;

    }
}
