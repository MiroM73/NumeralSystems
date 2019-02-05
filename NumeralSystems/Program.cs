﻿using System;

namespace NumeralSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            float sum = 0f;
            for (int i = 0; i < 1000; i++)
            {
                sum += 0.1f;
            }
            Console.WriteLine("Sum = {0}", sum);

            double sum = 0.0;
            for (int i = 1; i <= 10; i++)
            {
                sum += 0.1;
            }
            Console.WriteLine("{0:r}", sum);
            Console.WriteLine(sum);

            double sum = 0.0;
            for (int i = 1; i <= 100; i++)
            {
                sum += 0.1;
            }
            Console.WriteLine("{0:r}", sum);
            Console.WriteLine(sum);

            float sum = 0.0f;
            for (int i = 1; i <= 10; i++)
            {
                sum += 0.1f;
            }
            Console.WriteLine("{0:r}", sum);
            Console.WriteLine(sum);

            decimal sum = 0.0m;
            for (int i = 1; i <= 10000000; i++)
            {
                sum += 0.0000001m;
            }
            Console.WriteLine(sum);

            char ch = 'A';
            Console.WriteLine(ch);
            */

            //1.Convert the numbers 151, 35, 43, 251, 1023 and 1024 to the binary numeral system.

            //2.Convert the number 1111010110011110(2) to hexadecimal and decimal numeral systems.

            // 3.Convert the hexadecimal numbers FA, 2A3E, FFFF, 5A0E9 to binary and decimal numeral systems.

            //4.Write a program that converts a decimal number to binary one.

            //5.Write a program that converts a binary number to decimal one. 

            //6.Write a program that converts a decimal number to hexadecimal one.

            //7.Write a program that converts a hexadecimal number to decimal one. 

            //8.Write a program that converts a hexadecimal number to binary one. 

            //9.Write a program that converts a binary number to hexadecimal one. 

            //10.Write a program that converts a binary number to decimal using the Horner scheme.

            //11.Write a program that converts Roman digits to Arabic ones.

            //12.Write a program that converts Arabic digits to Roman ones.

            //13.Write a program that by given N, S, D (2 ≤ S, D ≤ 16) converts the number
            //N from an S-based numeral system to a D based numeral system. 
            
            //14.Try adding up 50,000,000 times the number 0.000001.Use a loop
            //and addition(not direct multiplication). Try it with float and double and
            //after that with decimal.Do you notice the huge difference in the
            //results and speed of calculation? Explain what happens.
            Console.WriteLine("EX:14 compare result for float, double and decimal");
            Console.WriteLine("Add real number 0.000001 50 000 000 times using float, double and decimal type:");
            float numberFloat = 0.0f;
            for (int i = 0; i < 50000000; i++)
            {
                numberFloat += 0.000001f;
            }            
            Console.WriteLine($"Float: {numberFloat} not accurate result, but the high speed.");

            double numberDouble = 0.0d;
            for (int i = 0; i < 50000000; i++)
            {
                numberDouble += 0.000001d;
            }            
            Console.WriteLine($"Double: {numberDouble} not accurate result, but the high speed.");

            decimal numberDecimal = 0.0M;
            for (int i = 0; i < 50000000; i++)
            {
                numberDecimal += 0.000001M;
            }            
            Console.WriteLine($"Decimal: {numberDecimal} the resault is accurate, but the speed is slowest.");
            EndOfScript();

            //15. * Write a program that prints the value of the mantissa, the sign of the
            //mantissa and exponent in float numbers(32 - bit numbers with a
            //floating - point according to the IEEE 754 standard). Example: for the
            //number - 27.25 should be printed: sign = 1, exponent = 10000011,
            //mantissa = 10110100000000000000000.

        }

        static void EndOfScript ()
        {
            Console.WriteLine(new String('#', 80));
            Console.WriteLine();
        }
    }
}
