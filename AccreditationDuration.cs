using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    public class AccreditationDuration
    {
        public static string computeDuration()
        {
            string start = DateTime.Now.AddYears(1).Year.ToString() + "-01-01";
            DateTime end = Convert.ToDateTime(start).AddYears(1);

            return end.ToString("yyyy-mm-dd");
        }
    }
}
