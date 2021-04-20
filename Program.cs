using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Program : CUI
    {
        static void Main(string[] args)
        {
            try
            {
                ShowCUI();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
        }
    }
}
