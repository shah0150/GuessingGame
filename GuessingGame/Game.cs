//Author : Adesh Shah
//
//Date : April 21,2016


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace GuessingGame
{

    //create menu
    //capture user choice using string -> byte
    //0-3
    class Game : RandomNumber     {
        //Feilds
        private SpeechSynthesizer speech;

        private ushort guess;
        private RangeRandomNumber rangeNumber;
        private String input;
        private UInt16 randomNumber;
     


        public Game()
        {
            guess = 0;
            input = String.Empty;
            rangeNumber = new RangeRandomNumber();
            randomNumber = 0;
            speech = new SpeechSynthesizer();
        }
        public ushort Menu()
        {
            Console.Clear();
            guess = 0;
            speech.Speak("Welcome to the game");
            Console.WriteLine("Welcome to 'Guess the Number'");
            
            Console.WriteLine("**********");
            Console.WriteLine("\n");
            Console.WriteLine("**********");
            Console.WriteLine("\n");
            speech.Speak("Select your level Easy, or Medium or Hard");
            Console.WriteLine(" 1 = Easy \t  1-20");
    
            Console.WriteLine(" 2 = Medium \t 1-100");
      
            Console.WriteLine(" 3 = Hard       1-1000");
           
            Console.WriteLine(" 0 = Exit program");
            speech.Speak("Great! Good Luck");
            Console.WriteLine("\n");
            Console.WriteLine("**********");
            Console.WriteLine("\n\n");
            byte userInput = 0;
            do
            {

                try
                {
                    input = Console.ReadLine();
                    userInput = Convert.ToByte(input);
                }
                   
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (userInput > 3);


            return GameSetup(userInput);
        }

        private UInt16 GameSetup(byte userInput)
        {
            rangeNumber.SetMinimum(1);
            switch (userInput)
            {
                case 0:
                    Console.WriteLine("You are about to quit");
                    return 0;
                case 1:

                    rangeNumber.SetMaximum(20);
                    
                    randomNumber = (UInt16)rangeNumber.GenerateRandomNumber();
                    return randomNumber;

                case 2:
                    rangeNumber.SetMaximum(100);
                    
                    randomNumber = (UInt16)rangeNumber.GenerateRandomNumber();
                    return randomNumber;

                case 3:
                    rangeNumber.SetMaximum(1000);
                    
                    randomNumber = (UInt16)rangeNumber.GenerateRandomNumber();
                    return randomNumber;

                    
            }
            return 0;
        }

        public void PlayGame(ushort number)
        {
            Console.Clear();
            Console.Write("Difficulty: ");

            if (input == "1")
            {
                Console.Write("EASY\n");
            }
            else if(input == "2")
            {
                Console.Write("MEDIUM\n");
            }
            else if(input == "3")
            {
                Console.Write("HARD\n");
            }

            do
            {
                Console.WriteLine("Please Enter the number");
                input = Console.ReadLine();
                guess++;

                try
                {
                    if (UInt16.Parse(input) < number)
                    {
                        Console.WriteLine("Guess higher");
                        

                    }
                    if (UInt16.Parse(input) > number)
                    {
                        Console.WriteLine("Guess lower");
                        




                    }
                    if(UInt16.Parse(input) == number)
                    {
                        Console.WriteLine("Winner");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (UInt16.Parse(input) != number);

           Console.WriteLine("Congratulations!!!! your was guess right!. Number of guess :" + guess);
            speech.Speak("Congratulations!!!! You have succesfully completed this game with total count of" + guess);
            speech.Speak("Here is the song for you by Eric Cartman");
            speech.Speak("In the ghetto On a cold and gray Chicago morn another little baby child is born In the ghetto.In the ghetto. And his momma cried. Cause if there's one thing that she don't need is another little hungry mouth to feed. In the ghetto.In the ghetto.");
            Console.WriteLine("Would you like to play again??");
            return;
            
            
        }
            
    }
}
