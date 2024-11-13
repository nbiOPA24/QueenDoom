//using System;
////TO DO List !
////Add companion class
////Add companion options
////Add Inventory class (list option)
////World-building levels
////Add minigames,puzzle,quiz
////Enemy class

//Console.WriteLine("*=*=*=*=*=*=*=*=*=*=*=*");
//Console.WriteLine("What choice to be choosen:");
//Console.WriteLine("1. Read about the main character Lilith, -backround story-");
//Console.WriteLine("2. Begin your Journey");
//Console.WriteLine("3. I was too afraid to go on, End it.");
//Console.WriteLine("*=*=*=*=*=*=*=*=*=*=*=*");
//string input = Console.ReadLine();

//switch (input)
//{
//    case "1":
//        Console.WriteLine("In this game you will be playing as Lilith, a 22 year old young lady");
//        Console.WriteLine("Lilith used to have a little sister called Emma");
//        Console.WriteLine("With only 2 years apart, they were inseparable");
//        Console.WriteLine("They had lost both their parents in a tragic car accident when they we're just 4 and 6 years old");
//        Console.WriteLine("Flash forward 6 years");
//        Console.WriteLine("Lilith and Emma had been living with their aunt Jamiene ever since the accident");
//        Console.Clear();
//        Console.WriteLine("Lilith : Mom used to say that She and Jamiene had special powers that only they knew about");
//        Console.WriteLine("Lilith : Hmm, she used to say it started back when the were our age, on a normal day, while playing the the woods, they found something,a paper or a magical tablet, noo it was this book made from tree bark");
//        Console.WriteLine("Lilith and Emma found the book and started using the spells inside and one day, a person or something came and grabbed Emma in the night. Lilith is positive she saw a black shaped person with some kind of pointy hat");
//        // Add more backstory, fix errors, bla bla
//        Console.WriteLine("Looking for her long lost little sister, which she know she saw someone or something come and grab her " +
//            "younger sister");
//        break;


//    case "2":
//        Console.Clear();
//        Console.WriteLine("Welcome to QueenDoom!");
//        Console.WriteLine("This is a Text Adventure Game");
//        Console.WriteLine("In this game, you will be put through mental and text based pysical strain upon your body !");
//        Console.WriteLine("You will solve mini games, gain and find items, clues where to go next");
//        Console.WriteLine("You will also be able to gain support, in the form of companions you find along the way.");
//        Console.WriteLine("So don't always use force to make your way forward, for example, i heard you can calm and gain the trust of hostile animals by offering them something");
//        Console.WriteLine("Please press any Key to continue");
//        break;

//    case "3":
//        Console.WriteLine("I was too afraid to go on, End it.");
//        return;

//    default:
//        Console.WriteLine("Wrong, So wrong");
//        break;
//}



//Console.ReadKey();
//Console.Clear();

//Console.WriteLine("Welcome, You have choosen your Doom, QueenDoom");
//Console.WriteLine("You have just arrived at your first location");
//Console.WriteLine("A smaller farm, A big main house called MasterA, with 2 smaller ones one each side, called sideB and SideC");
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine("When making the choice, please write MasterA,SideB or SideC as your answer");

//Console.Write("> ");
//string houseChoice = Console.ReadLine();

//if (houseChoice == "MasterA")
//{
//    Console.WriteLine("You walk up to the main house");
//    Console.WriteLine("You now stand infront of the door");
//}
//else if (houseChoice == "SideB")
//    Console.WriteLine("You have turned left and walked up to small house SideB");


//else if (houseChoice == "SideC")
//    Console.Clear();
//    Console.WriteLine("You have turned right and walked up to small house SideC");

//Console.ReadLine();

// comit fredag 8/11 klockan 11.00
using System;

namespace QueenDoom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}