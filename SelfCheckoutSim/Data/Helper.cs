using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfCheckoutSim.Data
{
    public static class Helper
    {
        public static string getPlu (string plu, string name)
        {
            string tempPlu = "";
            if (plu.Equals("") || plu == "")
            {
                int i = 0;
                while (tempPlu.Length < 11)
                {
                    int ascii = name[i];
                    tempPlu += ascii;
                    i++;
                }
            }
            else
            {
                tempPlu = plu;
            }

            return tempPlu;
        }
    }
}
