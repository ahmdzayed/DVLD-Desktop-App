using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_App.Global_Classes
{
    internal class clsFormats
    {
        public static string DateToShort(DateTime dateTime)
        {

            return dateTime.ToString("dd/MMM/yyyy");
        }

    }
}
