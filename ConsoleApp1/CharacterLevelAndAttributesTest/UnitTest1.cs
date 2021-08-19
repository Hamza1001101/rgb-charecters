using System;
using Xunit;
using Assignment1_RPG;
using System.Collections.Generic;

namespace CharacterLevelAndAttributesTest
{
    public class UnitTest1
    {
        /// <summary>
        /// Test for checking that Character levels and attributes are working properly.
        /// </summary>

        
        [Fact]      
        public void Level_CharacterLevelUponCreation_ShouldBeLevel1()
        {
            //Arrange
            Warrior Warrior1 = new Warrior();

            //Act
            int actual = Warrior1.Level;
            int expected = 1;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]      
        public void LevelUp_CharacterGainsLevel_LevelShouldBe2()
        {

            //Arrange
            Warrior Warrior1 = new Warrior();
            Warrior1.LevelUp();


            //Act
            int expected = 2;
            int actual = Warrior1.Level;

            //Assert

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void LevelUp_LevelingUpACharacterIncorrectly_ShouldThrowArgumentException(int levels)
        {

            Warrior Warrior1 = new Warrior();

            Assert.Throws<InvalidLevelInputException>(() => Warrior1.Leveler(levels));
        }

        [Fact]
        public void Warrior_HasProperDefaultAttributes_ShouldBeLevel1Stats()
        {
            //Arrange
            Warrior Warrior1 = new Warrior();
            

            //Act
            Dictionary<string, double> actual = Warrior1.PrimaryStats;
            Dictionary<string, double> expected = new() { { "Vitality", 10 }, { "Strength", 5 }, { "Dexterity", 2 }, { "Intelligence", 1 } };
            //Assert


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_HasProperDefaultAttributes_ShouldBeLevel1Stats()
        {

            //Arrange
            Rogue Rogue1 = new Rogue();

            //Act
            Dictionary<string, double> expected = new() { { "Vitality", 8 }, { "Strength", 2 }, { "Dexterity", 6 }, { "Intelligence", 1 } };
            Dictionary<string, double> actual = Rogue1.PrimaryStats;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_HasProperDefaultAttributes_ShouldBeLevel1Stats()
        {

            //Arrange
            Ranger Ranger1 = new Ranger();

            //Act
            Dictionary<string, double> expected = new() { { "Vitality", 8 }, { "Strength", 1 }, { "Dexterity", 7 }, { "Intelligence", 1 } };
            Dictionary<string, double> actual = Ranger1.PrimaryStats;

            //Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Mage_HasProperDefaultAttributes_ShouldBeLevel1Stats()
        {
            //Arrange
            Mage Mage1 = new Mage();

            //Act
            Dictionary<string, double> expected = new() { { "Vitality", 5 }, { "Strength", 1 }, { "Dexterity", 1 }, { "Intelligence", 8 } };
            Dictionary<string, double> actual = Mage1.PrimaryStats;

            //Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void RangerLevelup_StatsIncreasingWhenGainingLevel_ShouldBeCalculatedWhenLevelingUp()
        {
            //Arrange
            Ranger Ranger1 = new Ranger();
            Ranger1.LevelUp();

            //Act
            Dictionary<string, double> expected = new() { { "Vitality", 10 }, { "Strength", 2 }, { "Dexterity", 12 }, { "Intelligence", 2 } };
            //Assert
            Dictionary<string, double> actual = Ranger1.PrimaryStats;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MageLevelup_StatsIncreasingWhenGainingLevel_ShouldBeCalculatedWhenLevelingUp()
        {
            //Arrange
            Mage Mage1 = new Mage();
            Mage1.LevelUp();

            //Act
            Dictionary<string, double> expected = new() { { "Vitality", 8 }, { "Strength", 2 }, { "Dexterity", 2 }, { "Intelligence", 13 } };

            Dictionary<string, double> actual = Mage1.PrimaryStats;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RogueLevelup_StatsIncreasingWhenGainingLevel_ShouldBeCalculatedWhenLevelingUp()
        {
            //Arrange
            Rogue Rogue1 = new Rogue();
            Rogue1.LevelUp();


            //Act
            Dictionary<string, double> expected = new() { { "Vitality", 11 }, { "Strength", 3 }, { "Dexterity", 10 }, { "Intelligence", 2 } };

            Dictionary<string, double> actual = Rogue1.PrimaryStats;

            //Assert
            Assert.Equal(expected, actual);



        }

        [Fact]
        public void WarriorLevelup_StatsIncreasingWhenGainingLevel_ShouldBeCalculatedWhenLevelingUp()
        {
            //Arrange
            Warrior Warrior1 = new Warrior();
            Warrior1.LevelUp();

            //Act
            Dictionary<string, double> expected = new() { { "Vitality", 15 }, { "Strength", 8 }, { "Dexterity", 4 }, { "Intelligence", 2 } };

            Dictionary<string, double> actual = Warrior1.PrimaryStats;


            //Assert
            Assert.Equal(expected, actual);
        }

        //This test fails for some reason even though the expected and actual output are seemingly identical.
        [Fact]
        public void Warrior_SecondaryStatsAreCalculated_ShouldBeCalculatedWhenLevelingUp()
        {
            //Arrange
            Warrior Warrior1 = new Warrior();
            Warrior1.LevelUp();


            //Act
            Dictionary<string, double> expected = new() { { "Health", 150 }, { "ArmorRating", 12 }, { "Elementalresistance", 2 } };

            Dictionary<string, double> actual = Warrior1.SecondaryStats;
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
