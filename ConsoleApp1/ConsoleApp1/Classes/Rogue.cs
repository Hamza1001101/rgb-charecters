using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{
   public class Rogue : BaseClass
    {
        //Initializes the class to level 1 with the proper stats.
        public Rogue()
        {
            this.CharacterName = "Rogue";
            SetPrimaryAttribute(1, 2, 8, 6); //INT STR VIT DEX
            this.Level = 1;
            SetSecondaryAttribute();

            //Specifying which Armor and Weapon types the class can wield
            List<Weapon.WeaponType> allowedWeapontype = new();
            allowedWeapontype.Add(Weapon.WeaponType.WEAPON_DAGGER);
            allowedWeapontype.Add(Weapon.WeaponType.WEAPON_SWORD);
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

            TotalVitality += 3;
            TotalStrength+= 1;
            TotalDexterity += 4;
            TotalIntelligence += 1;

            PrimaryStats["Vitality"] = TotalVitality;
            PrimaryStats["Strength"] = TotalStrength;
            PrimaryStats["Dexterity"] = TotalDexterity;
            PrimaryStats["Intelligence"] = TotalIntelligence;
            SetSecondaryAttribute();
            

        }
    }
}
