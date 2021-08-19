using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RPG
{
   public class Armour : BaseArmour
    {
        //Contains fields for Armourtypes and Itemslots

        public ArmourType armourType { get; set; }
        public ItemSlot itemSlot { get; set; }
    }
}
