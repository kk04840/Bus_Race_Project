using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Race_Project
{
   public class ResultDeclare
    {
        //this code is used to reset the amount 
        public int result(int balance,int better,int Amount,int Winner) {
            if (better==Winner) {
                return balance + Amount;
            }
            else {
                return balance - Amount;
            }
        }

    }
}
