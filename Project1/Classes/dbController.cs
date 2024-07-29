using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AAJControl;
using System.Configuration;
using Project1.Models;
using System.Reflection.Emit;

namespace Project1.Classes
{
    public class dbController : DBControl
    {
        public dbController() : base(DatabaseType.MSSQL, ConfigurationManager.ConnectionStrings["MyProject"].ConnectionString)
        {

        }

        public object UserAccounts { get; internal set; }
    }
}