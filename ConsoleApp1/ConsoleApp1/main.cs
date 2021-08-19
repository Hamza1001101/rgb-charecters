using System;


namespace Assignment1_RPG
{
    class Program
    {
        public string ChooseCharacter { get; set; }
     
        public static object NewCharacter { get; private set; }


        //Main Function that calls the StartGame method.
       public static void Main(string[] args)
        {

            StartGame();
            
        }
        
        //Function that inatalizes every class and prompts the user to choose the class they want to play.
        public static void StartGame()
        {
            Ranger Ranger1 = new Ranger();
            Mage Mage1 = new Mage();
            Warrior Warrior1 = new Warrior();
            Rogue Rogue1 = new Rogue();

            Console.WriteLine("Welcome, please choose a class: Warrior, Mage, Rogue, Ranger");

            string ChooseCharacter = Console.ReadLine();
            if (ChooseCharacter.ToLower() == "warrior")
            {
                Console.WriteLine("Warrior created");
                Warrior1.NewAction();
            }

            if (ChooseCharacter.ToLower() == "mage")
            {
             
                Console.WriteLine("Mage created");
                Mage1.NewAction();
            }

            if (ChooseCharacter.ToLower() == "rogue")
            {
                
                Console.WriteLine("Rogue created");
                Rogue1.NewAction();
            }

            if (ChooseCharacter.ToLower() == "ranger")
            {
                
                Console.WriteLine("Ranger created");
                Ranger1.NewAction();
            }

            else
            {
                Console.WriteLine("invalid input, please chose between the available classes.\nAVAILABLE CLASSES:\nwarrior\nmage\nrogue \nranger");
                StartGame();
            }

           




        }



    }
}
    
           
