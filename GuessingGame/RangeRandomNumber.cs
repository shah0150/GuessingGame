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
    sealed class RangeRandomNumber : RandomNumber 
    {
        private byte minimum;
        private ushort maximum;

        public RangeRandomNumber()
        {
            minimum = 0;
            maximum = 0;
        }
        public RangeRandomNumber(byte minimum, ushort maximum)
        {
            this.minimum = minimum;
            this.maximum = maximum;
        }
        public new int GenerateRandomNumber()
        {
            currentRandomNumber = random.Next(minimum,maximum + 1);
            return currentRandomNumber;
        }
        public bool SetMinimum(byte minimum)
        {
            if (minimum != 1)
            {
                return false;
            }
            else
            {
                try {

                    this.minimum = minimum;
                    return true;
                }
                catch
                {
                    Console.WriteLine("please enter a number");
                }
            }
            return false;
        }
        public bool SetMaximum(ushort maximum)
            {
            if ((maximum > 19) && (maximum < 1001))
            {
                try {
                    this.maximum = maximum;
                    return true;
                }
                catch
                {
                    Console.WriteLine("please enter a number");
                }
            }
            return false;
            }
        public byte GetMinimum()
        {
            return minimum;
        }
        public ushort GetMaximum()
        {
            return maximum;
        }
    }
}
