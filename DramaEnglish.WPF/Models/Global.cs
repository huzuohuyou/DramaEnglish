using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DramaEnglish.WPF.Models
{
    public class Global
    {
        private static User _currentUser;
        public static User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public static string Authorization { get; set; }
    }
}
