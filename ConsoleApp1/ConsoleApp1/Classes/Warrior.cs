using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{
   public class Warrior : BaseClass
    {

        //Initializes the class to level 1 with the proper stats.
        public Warrior()
        {
            this.CharacterName = "Warrior";
            SetPrimaryAttribute(1, 5, 10, 2); //INT STR VIT DEX
            this.Level = 1;
            SetSecondaryAttribute();            
           
            //Specifying which Armor and Weapon types the class can wield

            List<Weapon.WeaponType> allowedWeapontype = new();
            allowedWeapontype.Add(Weapon.WeaponType.WEAPON_AXE);
            allowedWeapontype.Add(Weapon.WeaponType.WEAPON_HAMMER); 
            allowedWeapontype.Add(Weapon.WeaponType.WEAPON_SWORD);
            Allowedweapontype = allowedWeapontype;


            List<Armour.ArmourType> allowedarmortype = new();
            allowedarmortype.Add(Armour.ArmourType.ARMOUR_MAIL);
            allowedarmortype.Add(Armour.ArmourType.ARMOUR_PLATE);
            Allowedarmortype = allowedarmortype;                     
    }
        
        //Function that increases the level by 1 
        public override void LevelUp()
        {
           Level += 1;

            TotalVitality += 5;
            TotalStrength += 3;
            TotalDexterity += 2;
            TotalIntelligence += 1;

            PrimaryStats["Vitality"] = TotalVitality;
            PrimaryStats["Strength"] = TotalStrength;
            PrimaryStats["Dexterity"] = TotalDexterity;
            PrimaryStats["Intelligence"] = TotalIntelligence;

            SetSecondaryAttribute();
           

        }
        //Returns DPS based on the classes Damage-increasing attribute
        public override void ReturnDamage()
        {
            CalculateDamage(TotalStrength);
        }
    }
}
