using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSAF.Helper
{
   public class Validation
    {
        public static bool AllowNumbers(KeyPressEventArgs e)
        {
            bool Allow = true;
            int ascii = e.KeyChar;
            if((ascii >= 47 && ascii <= 57) || ascii == 46 || ascii == 8)
            {
                Allow = false;
            }
            else
            {
                Allow = true;
            }
            return Allow;
        }
    }
}
