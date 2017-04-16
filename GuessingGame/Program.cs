//Author : Adesh Shah
//
//Date : April 21,2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
             String pinput = String.Empty;
        Game newGame = new Game();

            
            
            do
	        {
                UInt16 magicNumber = newGame.Menu();
                newGame.PlayGame(magicNumber);
                Console.WriteLine("(n/N) to exit, any other key to continue");

                pinput = Console.ReadLine();

	        } while (pinput.Equals("n", StringComparison.InvariantCultureIgnoreCase));

            return;
        }
    }
}