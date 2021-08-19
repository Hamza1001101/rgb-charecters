using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{
   public  class Mage : BaseClass
    {
        //Initializes the class to level 1 with the proper stats.
        public Mage()
        {
            this.CharacterName = "Mage";
            SetPrimaryAttribute(8, 1, 5, 1);
            this.Level = 1;
            SetSecondaryAttribute();

            //Specifying which Armor and Weapon types the class can wield
            List<Weapon.WeaponType> allowedWeapontype = new();
            allowedWeapontype.Add(Weapon.WeaponType.WEAPON_STAFF);
            allowedWeapontype.Add(Weapon.WeaponType.WEAPON_WAND);
            Allowedweapontype = allowedWeapontype;

            List<Armour.ArmourType> allowedarmortype = new();
            allowedarmortype.Add(Armour.ArmourType.ARMOUR_CLOTH);
            
            Allowedarmortype = allowedarmortype;
        }


        //Returns DPS based on the classes Damage-increasing attribute
        public override void ReturnDamage()
        {
            CalculateDamage(TotalIntelligence);
        }

        public override void LevelUp()
        {
            Level += 1;

            TotalVitality += 3;
            TotalStrength += 1;
            TotalDexterity += 1;
            TotalIntelligence += 5;

            PrimaryStats["Vitality"] = TotalVitality;
            PrimaryStats["Strength"] = TotalStrength;
            PrimaryStats["Dexterity"] = TotalDexterity;
            PrimaryStats["Intelligence"] = TotalIntelligence;
            SetSecondaryAttribute();
            

        }
    }
}
           

    
