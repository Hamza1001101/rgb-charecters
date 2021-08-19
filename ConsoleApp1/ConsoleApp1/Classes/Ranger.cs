using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{
   public class Ranger : BaseClass 
    {
        //Initializes the class to level 1 with the proper stats.
        public Ranger()
        {
            this.CharacterName = "Ranger";
            SetPrimaryAttribute(1, 1, 8, 7); //INT STR VIT DEX
            this.Level = 1;
            SetSecondaryAttribute();


            //Specifying which Armor and Weapon types the class can wield
            List<Weapon.WeaponType> allowedWeapontype = new();
            allowedWeapontype.Add(Weapon.WeaponType.WEAPON_BOW);
            Allowedweapontype = allowedWeapontype;


            List<Armour.ArmourType> allowedarmortype = new();
            allowedarmortype.Add(Armour.ArmourType.ARMOUR_LEATHER);
            allowedarmortype.Add(Armour.ArmourType.ARMOUR_MAIL);
            Allowedarmortype = allowedarmortype;
        }

        //Returns DPS based on the classes Damage-increasing attribute
        public override void ReturnDamage()
        {
            CalculateDamage(TotalDexterity);
        }


        public override void LevelUp()
        {
            Level += 1;

            TotalVitality += 2;
            TotalStrength += 1;
            TotalDexterity += 5;
            TotalIntelligence += 1;

            PrimaryStats["Vitality"] = TotalVitality;
            PrimaryStats["Strength"] = TotalStrength;
            PrimaryStats["Dexterity"] = TotalDexterity;
            PrimaryStats["Intelligence"] = TotalIntelligence;
            SetSecondaryAttribute();
            

        }

    }
}
