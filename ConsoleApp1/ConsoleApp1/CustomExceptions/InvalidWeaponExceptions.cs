using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{
    //Custom Exceptions that are used in the EquipWeapon Method in BaseClass
   public class InvalidWeaponExceptions : Exception
    {
        public InvalidWeaponExceptions()
        {

        }

        public string LevelException(int Level, int ItemLevel)
        {
            return $"Your level is not high enough to equip that weapon. Current level: {Level}, Required level:{ItemLevel}\n";
        }

        public string WeaponTypeException => "Your class cant equip that type of weapon\n";
    }
}

