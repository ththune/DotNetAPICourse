using System;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Exercise
    {
        static void Main(string[] args)
        {
            int myFirstValue = 7;
            int mySecondValue = 5;
            //Write Your Code Here
            mySecondValue += myFirstValue;
            myFirstValue -= mySecondValue;
            myFirstValue *= mySecondValue;

            Console.WriteLine(myFirstValue);
            Console.WriteLine(mySecondValue);
            Console.WriteLine(myFirstValue > mySecondValue);
            
            //Console.WriteLine(myFirstValue mySecondValue);
            
            //Write You Code Above This Line
        }
    }
}
