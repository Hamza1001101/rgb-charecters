using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{
    public  class Item : BaseClass
    {
        //Fields that contains attributes that items can have.

        public string ItemName { get; set; }
        public int ItemLevel { get; set; }

        public int Damage { get; set; }
        public double AttackSpeed { get; set; }

        public double DPS { get => Damage * AttackSpeed; }
        public override void ReturnDamage()
        {
            throw new NotImplementedException();
        }

        //Enumerator for available ItemSlots.
        public enum ItemSlot 
        {
            Slot_Head,
            Slot_Body,
            Slot_Legs,
            Slot_Weapon

        }


    }

}
