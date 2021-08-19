using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{
   public class BaseWeapon :Item
    {
        //Enumerator that Contains the available WeaponTypes.
        public enum WeaponType
        {
            WEAPON_AXE,
            WEAPON_BOW,
            WEAPON_DAGGER,
            WEAPON_HAMMER,
            WEAPON_STAFF,
            WEAPON_SWORD,
            WEAPON_WAND,
        }
    }
}
