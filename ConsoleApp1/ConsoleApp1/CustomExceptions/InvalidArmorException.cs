using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{

    //Custom Exceptions that are used in the ArmorEquipper method in BaseClass
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException()
        {

        }

        public string LevelException(int Level, int ItemLevel)
        {
            return $"Your level is not high enough to equip that armor. Current level: {Level}, Required level:{ItemLevel}\n";
        }

        public string ArmourTypeException => "Your class cant equip that type of armor";

        public string ArmourSlotException => "You cant equip armor in a weapon slot";

    }
}
