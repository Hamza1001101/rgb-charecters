using System;
using Xunit;
using Assignment1_RPG;
using System.Collections.Generic;
using static Assignment1_RPG.Item;
using static Assignment1_RPG.BaseWeapon;
using static Assignment1_RPG.BaseArmour;

namespace EquipmentTest
{

    /// <summary>
    /// UnitTest for check that the Equipment methods has the intended functionalities
    /// </summary>
    public class UnitTest1
    {
        [Fact]
        public void EquipWeapon_EquippingWeaponWithTooHighItemLevel_ExceptionShouldBeThrown()
        {
            Warrior warrior1 = new Warrior();
            Weapon weapon = new Weapon()
            {
                ItemName = "common axe",
                ItemLevel = 2,
                itemSlot = ItemSlot.Slot_Weapon,
                weaponType = WeaponType.WEAPON_AXE,
                AttackSpeed = 1.1,
                Damage = 7,
                Strenght = 50,
            };

            Assert.Throws<InvalidWeaponExceptions>(() => warrior1.EquipWeapon(weapon));
        }

        [Fact]
        public void EquipArmor_EquippingArmorWithTooHighItemLevel_ExceptionShouldBeThrown()
        {
            Warrior warrior1 = new Warrior();
            Armour armour1 = new Armour()
            {
                ItemName = "common plate body armor",
                ItemLevel = 2,
                itemSlot = ItemSlot.Slot_Body,
                armourType = ArmourType.ARMOUR_PLATE,
                Vitality = 2,
                Strenght = 1,
            };

            Assert.Throws<InvalidArmorException>(() => warrior1.EquipArmor(armour1, ItemSlot.Slot_Body));
        }


        [Fact]
        public void EquipWeapon_EquippingWeaponWithWrongType_ExceptionShouldBeThrown()
        {
            Warrior warrior1 = new Warrior();
            Weapon weapon = new Weapon()
            {
                ItemName = "common bow",
                ItemLevel = 1,
                itemSlot = ItemSlot.Slot_Weapon,
                weaponType = WeaponType.WEAPON_BOW,
                AttackSpeed = 1.5,
                Damage = 8,
            };

            Assert.Throws<InvalidWeaponExceptions>(() => warrior1.EquipWeapon(weapon));
        }

        [Fact]
        public void EquipArmor_EquippingArmorWithWrongType_ExceptionShouldBeThrown()
        {
            Warrior warrior1 = new Warrior();
            Armour armour1 = new Armour()
            {
                ItemName = "common cloth head armor",
                ItemLevel = 1,
                itemSlot = ItemSlot.Slot_Head,
                armourType = ArmourType.ARMOUR_CLOTH,
                Vitality = 1,
                Intelligence = 5,
            };

            Assert.Throws<InvalidArmorException>(() => warrior1.EquipArmor(armour1, ItemSlot.Slot_Body));
        }

        [Fact]

        public void EquipWeapon_EquippingCorrectWeaponType_ShouldReturnMessage()
        {
            
            //Arrange
            Warrior warrior1 = new Warrior();
            Weapon weapon = new Weapon()
            {
                ItemName = "common axe",
                ItemLevel = 1,
                itemSlot = ItemSlot.Slot_Weapon,
                weaponType = WeaponType.WEAPON_AXE,
                AttackSpeed = 1.1,
                Damage = 7,
                Strenght = 50,
            };

            //Act
            string expected = "New Weapon Equipped!";
            string actual = warrior1.EquipWeapon(weapon);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]

        public void EquipArmor_EquippingCorrectArmorType_ShouldReturnMessage()
        {

            //Arrange
            Warrior warrior1 = new Warrior();
            Armour armour1 = new Armour()
            {
                ItemName = "common plate body armor",
                ItemLevel = 1,
                itemSlot = ItemSlot.Slot_Body,
                armourType = ArmourType.ARMOUR_PLATE,
                Vitality = 2,
                Strenght = 1,
            };

            //Act
            string expected = "New Armor Equipped!";
            string actual = warrior1.EquipArmor(armour1,ItemSlot.Slot_Body);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]

        public void DPS_CalculateDpsWithNoWeaponEquipped_ShouldBe1()
        {

            //Arrange
            Warrior warrior1 = new Warrior();
            warrior1.ReturnDamage();

            //Act
            double expected = 1.0 * (1.0 + (5.0 / 100.0));

            double actual = warrior1.TotalDPS;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]

        public void DPS_CalculateDpsWithOneWeaponEquipped_ShouldBeCalculated()
        {

            //Arrange
            Warrior warrior1 = new Warrior();
            warrior1.ReturnDamage();
            Weapon weapon = new Weapon()
            {
                ItemName = "common axe",
                ItemLevel = 1,
                itemSlot = ItemSlot.Slot_Weapon,
                weaponType = WeaponType.WEAPON_AXE,
                AttackSpeed = 1.1,
                Damage = 7,

            };
            warrior1.EquipWeapon(weapon);
            warrior1.ReturnDamage();


            //Act
            double expected = (7.0 * 1.1) * (1.0 + (5.0 / 100.0));

            double actual = warrior1.TotalDPS;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]

        public void DPS_CalculateDPSWithValidWeaponAndArmor_ShouldBeIncreased()
        {

            //Arrange
            Warrior warrior1 = new Warrior();
            warrior1.ReturnDamage();
            Weapon weapon = new Weapon()
            {
                ItemName = "common axe",
                ItemLevel = 1,
                itemSlot = ItemSlot.Slot_Weapon,
                weaponType = WeaponType.WEAPON_AXE,
                AttackSpeed = 1.1,
                Damage = 7,
               
            };
            Armour armour1 = new Armour()
            {
                ItemName = "common plate body armor",
                ItemLevel = 1,
                itemSlot = ItemSlot.Slot_Body,
                armourType = ArmourType.ARMOUR_PLATE,
                Vitality = 2,
                Strenght = 1,
            };
         
            warrior1.EquipWeapon(weapon);
            warrior1.ReturnDamage();
            warrior1.EquipArmor(armour1, ItemSlot.Slot_Body);
            warrior1.ReturnDamage();
            

            //Act

            double expteced = (7.0 * 1.1) * (1.0 + ((5.0 + 1.0) / 100.0));

            double actual = warrior1.TotalDPS;

            //Assert
            Assert.Equal(expteced, actual);



        }

    }
}
