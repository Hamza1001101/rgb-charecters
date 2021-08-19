using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{

    //Custom exceptions that are used in the Leveler method in BaseClass
   public class InvalidLevelInputException : Exception
    {
        public InvalidLevelInputException()
        {

        }

        public string InvalidLevelInput()
        {
            return "You cant gain less than 1 level";
        }


    }

}

