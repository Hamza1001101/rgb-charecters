using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment1_RPG.BaseWeapon;
using static Assignment1_RPG.Item;
using static Assignment1_RPG.BaseArmour;

namespace Assignment1_RPG
{
    public abstract class BaseClass
    {
        /// <summary>
        /// THe Base class stores most of the functionality of the application.
        /// The application could be widely improved by assigning a lot of the different functionalities
        /// to different classes to avoid such a big dependancy.
        /// This will be kept in mind going further("SOLID PRINCIPLES")
        /// </summary>
        
        public string CharacterName { get; set; }
        public int Level { get; set; }



        public double TotalDPS { get; set; } = 1;

        //Empty Lists that stores Allowed Weapon and Armor types.
        public List<BaseWeapon.WeaponType> Allowedweapontype = new();
        public List<Armour.ArmourType> Allowedarmortype = new();

        //Equipment Dict
        public Dictionary<Item.ItemSlot, Item> Equipment = new();


        //Primary Attributes

        public Dictionary<string, double> PrimaryStats = new();
        public double Vitality { get; set; } //Increases Health by 10 points

        public double Strenght { get; set; }  // Increases Warrior Damage by 1%

        public double Dexterity { get; set; } // Increases Rogue and Ranger Damage by 1%

        public double Intelligence { get; set; } //Increases Mage Damage by 1%

        public double TotalVitality { get; set; }
        public double TotalStrength { get; set; }
        public double TotalDexterity { get; set; }
        public double TotalIntelligence { get; set; }


        //Method that sets primary attributes for a character.
        public void SetPrimaryAttribute(double intelligence, double strenght, double vitality, double dexterity)
        {
            Vitality = vitality;
            Strenght = strenght;
            Dexterity = dexterity;
            Intelligence = intelligence;

            TotalVitality += vitality;
            TotalStrength += strenght;
            TotalDexterity += dexterity;
            TotalIntelligence += intelligence;

            PrimaryStats["Vitality"] = TotalVitality;
            PrimaryStats["Strength"] = TotalStrength;
            PrimaryStats["Dexterity"] = TotalDexterity;
            PrimaryStats["Intelligence"] = TotalIntelligence;


        }


        //Secondary Attributes
        public double Health { get; set; } // Total vitality * 10

        public double ArmorRating { get; set; } // Total Strenght + Total Dexterity

        public double Elementalresistance { get; set; } //Total Intelligence

        public Dictionary<string, double> SecondaryStats = new();
       
        
        //Method that calculates secondary attributes
        public void SetSecondaryAttribute()
        {
            Health = TotalVitality * 10;
            ArmorRating = TotalStrength + TotalDexterity;
            Elementalresistance = TotalIntelligence;

            SecondaryStats["Health"] = Health;
            SecondaryStats["ArmorRating"] = ArmorRating;
            SecondaryStats["ElementalResistance"] = Elementalresistance;

        }



        
        /// <summary>
        /// Methods that calculates a characters DPS based on what weapon they have/have not equipped.
        /// If a character has a weapon equipped - The dps is calculated based on the weapon dps and 
        /// the characters damage amplifying attribute.
        /// If the character has no weapon equipped the dps is set to 1 and multiplied by the characters
        /// damage amplyfing attribute.
        /// 
        /// </summary>
        public abstract void ReturnDamage();
        public void CalculateDamage(double attr)
        {
            try
            {
                TotalDPS = Equipment[Item.ItemSlot.Slot_Weapon].DPS * (1 + (attr / 100));
                Console.WriteLine($"DPS: {TotalDPS}\n");
            }
            catch
            {
                TotalDPS = 1 * (1 + (attr / 100));
                Console.WriteLine($"DPS: {TotalDPS}\n");
            }
        }




        // Virtual LevelUp method that is implemented in the different CharacterClasses
        public virtual void LevelUp()
        {

        }


        //Function that displays the stats of the character.
        public void ShowStats()
        {
            Console.WriteLine($"Character Name: {this.CharacterName}\nLevel:{this.Level}\n Vitality:{this.TotalVitality}\n Strenght:{this.TotalStrength}\n " +
                              $"Dexterity:{this.TotalDexterity}\n Intelligence:{this.TotalDexterity}\n Armor Rating: {this.ArmorRating}\n " +
                              $"Health: {this.Health}\n Elemental Resistance:{this.Elementalresistance}\n");
        }


        /// <summary>
        /// Method that takes wanted levels to gain from the LevelUpCharacter Function
        /// If the input levels is lower than 1 - An exception is thrown.
        /// Else - The LevelUp method is called (levels) amount of times.
        /// </summary>
        /// <param name="levels"></param>
        public void Leveler(int levels )
        {
            if (levels < 1)
            {               
                throw new InvalidLevelInputException();
            }
            else 
            {
                for (int i = 0; i < levels; i++)
                {
                    LevelUp();
                }
            }
        }


        //Function that levels up that character based on user input
        public void LevelUpCharacter()
        {
            Console.WriteLine("Choose the amount of levels you want to gain");
            string numberOfLevels = Console.ReadLine();

            int convertedNumberOfLevels = int.Parse(numberOfLevels);
            Leveler(convertedNumberOfLevels);

        }

        //Function that prompts the user with available actions to execute and acts diferently based on the class you have chosen
        public void NewAction()
        {
            Console.WriteLine("Choose between the following actions:");
            Console.WriteLine("1: Levelup");
            Console.WriteLine("2: display stats.");
            Console.WriteLine("3: Equip Weapon");
            Console.WriteLine("4: Equip Armor");
            string action = Console.ReadLine();

            if (action == "1")
            {
                LevelUpCharacter();
                NewAction();

            }

            if (action == "2")
            {
                ShowStats();
                ReturnDamage();
                NewAction();
            }


            if (action == "3")
            {
                WeaponEquipper();

                NewAction();
            }

            if (action == "4")
            {
                ArmorEquipper();
                NewAction();
            }


            else
            {
                Console.WriteLine("You have chosen an unavailable action, please try again");
                NewAction();
            }

        }
        /// <summary>
        /// Method that gets called after the user has chosen the weapon they want to equip.
        /// If the Weapon type exists in the classes allowed weapontypes - Continue - if not - an exception is thrown
        /// If the Hero level matches the Itemlevel - Continue - if not - An exception is thrown
        /// The method then checks if there is a weapon currently equipped and replaces it - if not - Weapon is added to the designated slot.
        /// </summary>
        /// <param name="ChosenWeapon"></param>
        public string EquipWeapon(Weapon ChosenWeapon)
        {
            if (Allowedweapontype.Contains(ChosenWeapon.weaponType))
            {
                if (Level >= ChosenWeapon.ItemLevel)
                {
                    if (Equipment.ContainsKey(Item.ItemSlot.Slot_Weapon))
                    {
                        TotalVitality -= Equipment[Item.ItemSlot.Slot_Weapon].Vitality;
                        TotalStrength -= Equipment[Item.ItemSlot.Slot_Weapon].Strenght;
                        TotalDexterity -= Equipment[Item.ItemSlot.Slot_Weapon].Dexterity;
                        TotalIntelligence -= Equipment[Item.ItemSlot.Slot_Weapon].Intelligence;
                        Equipment.Remove(Item.ItemSlot.Slot_Weapon);
                        Equipment.Add(Item.ItemSlot.Slot_Weapon, ChosenWeapon);
                    }
                    else
                    {
                        Equipment.Add(Item.ItemSlot.Slot_Weapon, ChosenWeapon);
                    }

                    TotalVitality += Equipment[Item.ItemSlot.Slot_Weapon].Vitality;
                    TotalStrength += Equipment[Item.ItemSlot.Slot_Weapon].Strenght;
                    TotalDexterity += Equipment[Item.ItemSlot.Slot_Weapon].Dexterity;
                    TotalIntelligence += Equipment[Item.ItemSlot.Slot_Weapon].Intelligence;

                    SetSecondaryAttribute();
                    Console.WriteLine($"Trying to equip: {ChosenWeapon.ItemName}");
                    Console.WriteLine($"You successfully equipped: {ChosenWeapon.ItemName}!\n");

                    return "New Weapon Equipped!";
                }
                else
                {
                    throw new InvalidWeaponExceptions();
                }

            }
            else
            {
                throw new InvalidWeaponExceptions();
            }
        }



        /// <summary>
        /// This Method promts the user with a choice to equip a weapon.
        /// if their input matches the options that are given a weapon object of that type will be created
        /// This weapon then gets passed to the EquipWeapon method which checks if the Class can equip that weapon based on level and allowed types.
        /// If they cant equip it they get asked to choose a different weapon.
        /// </summary>
        public void WeaponEquipper()
        {
            Console.WriteLine("Choose a Weapon you want to equip:\n [Common axe , Common Bow , Great axe]");
            string ChooseWeapon = Console.ReadLine().ToLower();


            if (ChooseWeapon == "common axe")
            {
                Weapon testAxe = new Weapon()
                {
                    ItemName = "common axe",
                    ItemLevel = 1,
                    itemSlot = ItemSlot.Slot_Weapon,
                    weaponType = WeaponType.WEAPON_AXE,
                    AttackSpeed = 1.1,
                    Damage = 7,
                    Strenght = 50,
                };
                Weapon ChosenWeapon = testAxe;
                EquipWeapon(testAxe);

            }

            if (ChooseWeapon == "common bow")
            {

                Weapon testBow = new Weapon()
                {
                    ItemName = "common bow",
                    ItemLevel = 2,
                    itemSlot = ItemSlot.Slot_Weapon,
                    weaponType = WeaponType.WEAPON_BOW,
                    AttackSpeed = 1.5,
                    Damage = 8,

                };
                Weapon ChosenWeapon = testBow;
                EquipWeapon(testBow);

            }

            if (ChooseWeapon == "great axe")
            {

                Weapon greatAxe = new Weapon()
                {
                    ItemName = "great axe",
                    ItemLevel = 3,
                    itemSlot = ItemSlot.Slot_Weapon,
                    weaponType = WeaponType.WEAPON_AXE,
                    AttackSpeed = 1.1,
                    Damage = 25,
                };
                Weapon ChosenWeapon = greatAxe;
                EquipWeapon(greatAxe);

            }

        }

        /// <summary>
        /// Same Concept as the WeaponEquipper method, user gets prompted with a choice
        /// between which armor they want to equip.
        /// Based on their input that item gets created and initializes the EquipArmor function with their choice.
        /// Currently missing some error handling.
        /// </summary>

        public void ArmorEquipper()
        {
            Console.WriteLine("Choose armor you want to equip:\n [Commmon Plate Body Armor , Common Cloth Head Armor]");
            string ChooseArmor = Console.ReadLine();


            if (ChooseArmor.ToLower() == "common plate body armor")
            {
                Armour testPlateBody = new Armour()
                {
                    ItemName = "common plate body armor",
                    ItemLevel = 1,
                    itemSlot = ItemSlot.Slot_Body,
                    armourType = ArmourType.ARMOUR_PLATE,
                    Vitality = 2,
                    Strenght = 1,
                };
                Armour ChosenArmour = testPlateBody;
                EquipArmor(testPlateBody, testPlateBody.itemSlot);

            }
            if (ChooseArmor.ToLower() == "common cloth head armor")
            {
                Armour testClothHead = new Armour()
                {
                    ItemName = "common cloth head armor",
                    ItemLevel = 1,
                    itemSlot = ItemSlot.Slot_Head,
                    armourType = ArmourType.ARMOUR_CLOTH,
                    Vitality = 1,
                    Intelligence = 5,
                };
                Armour ChosenArmour = testClothHead;

                EquipArmor(testClothHead, testClothHead.itemSlot);

            }

        }



        /// <summary>
        /// Based on the choice of armor given in the ArmorEquipper method
        /// The EquipArmor function first checks if the slot of the item is a weapon slot
        /// If so - An exception is thrown - Else continues
        /// It then checks if the chosen items armortype is present in the classes allowed armortypes
        /// If so - An exception is thrown - Else Continues
        /// it then checks if the itemLevel corresponds with the characterlevel.
        /// If not - Exception is thrown - Else continues
        /// If all these checks are passed - It Equips the current item in given slot or replaces an item if that slot is taken.
        /// </summary>
        /// <param name="ChosenArmor"></param>
        /// <param name="ChosenSlot"></param>
        /// <returns></returns>


        public string EquipArmor(Armour ChosenArmor, Item.ItemSlot ChosenSlot)
        {
            if (ChosenSlot != Item.ItemSlot.Slot_Weapon)
            {
                if (Allowedarmortype.Contains(ChosenArmor.armourType))
                {
                    if (Level >= ChosenArmor.ItemLevel)
                    {
                        if (Equipment.ContainsKey(ChosenSlot))
                        {
                            TotalVitality -= Equipment[ChosenSlot].Vitality;
                            TotalStrength -= Equipment[ChosenSlot].Strenght;
                            TotalDexterity -= Equipment[ChosenSlot].Dexterity;
                            TotalIntelligence -= Equipment[ChosenSlot].Intelligence;
                            Equipment.Remove(ChosenSlot);
                            Equipment.Add(ChosenSlot, ChosenArmor);
                        }
                        else
                        {
                            Equipment.Add(ChosenSlot, ChosenArmor);
                        }

                        TotalVitality += Equipment[ChosenSlot].Vitality;
                        TotalStrength += Equipment[ChosenSlot].Strenght;
                        TotalDexterity += Equipment[ChosenSlot].Dexterity;
                        TotalIntelligence += Equipment[ChosenSlot].Intelligence;

                        SetSecondaryAttribute();
                        Console.WriteLine($"You try to equip {ChosenArmor.ItemName}");
                        Console.WriteLine($"You equipped {ChosenArmor.ItemName}!\n");
                        return "New Armor Equipped!";

                    }
                    else
                    {
                        throw new InvalidArmorException();
                    }
                }
                else
                {
                    throw new InvalidArmorException();

                }
            }
            else
            {
                throw new InvalidArmorException();
            }
        }    
    }
}
