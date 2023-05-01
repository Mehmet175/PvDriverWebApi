using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Utils
{
    /*
        Entity Framework Yükleme Komutu
        "Data Source=185.122.201.11;Initial Catalog=DRIVERS;Persist Security Info=True;User ID=sa;Password=tGi3#r94" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Ef -f

        Yayın Bilgileri
        https://gpdriverapi.alacasoft.com/swagger/index.html
        Ip :  89.252.180.81
        ftp : gpdriverapi 
        password : oI2e^3v11

        Database Bilgileri
        <add name="DRIVERSConnectionString" connectionString="Data Source=185.122.201.11;Initial Catalog=DRIVERS;Persist Security Info=True;User ID=sa;Password=tGi3#r94"
    */


    public class AppConstants
    {
        public static string JwtKey = "PvDriverWebAppJwtTokenKey";
        public static string SqlConnectionString = "Data Source=185.122.201.11;Initial Catalog=DRIVERS;Persist Security Info=True;User ID=sa;Password=tGi3#r94";
    }
}
