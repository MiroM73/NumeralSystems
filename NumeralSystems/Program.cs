using System;

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
            Console.WriteLine("EX1: Convert the numbers 151, 35, 43, 251, 1023 and 1024 to the binary numeral system.");
            int[] numbersToConvert = { 151, 35, 43, 251, 1023, 1024 };
            for (int i = 0; i < numbersToConvert.Length; i++)
            {
                int numberToConvert = numbersToConvert[i];
                string result = "";
                while (numberToConvert > 0)
                {
                    result = result.Insert(0, (numberToConvert % 2).ToString());
                    numberToConvert = numberToConvert / 2;
                }
                Console.WriteLine("{0} = {1}", numbersToConvert[i], result);
            }
            EndOfScript();

            //2.Convert the number 1111010110011110(2) to hexadecimal and decimal numeral systems.
            Console.WriteLine("EX2: Convert the number 1111010110011110(2) to hexadecimal and decimal numeral systems.");
            string[] conversionTable = ("0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F").Split(new char[] { ',' }); //convert numbers 0 .. 15 to string
            string binNumber = "1111010110011110";
            string resultHex = "";
            double resultDec = 0;
            char[] binNumberArray = binNumber.ToCharArray();
            //convert binary number to decimal
            for (int i = 0; i < binNumberArray.Length; i++)
            {
                //using algorithm for converting any numeral system to dec system;
                //in this exercise, every single binary digit is multiplied by 2 raised to the 
                //power of the position it is in. In the end all of the numbers resulting from
                //the binary digits are added up to get the decimal value of the binary number. 
                //example: 11001(bin) = 1×2^4 + 1×2^3 + 0×2^2 + 0×2^1 + 1×2^0 = 16 + 8 + 1 = 25
                //From this follows that 11001(bin) = 25(dec)
                resultDec += int.Parse(binNumberArray[i].ToString()) * Math.Pow(2, binNumberArray.Length - i - 1);
            }
            Console.WriteLine("Bin number {0} equal {1} in dec.", binNumber, resultDec);

            //convert decimal to hexa
            double resultDecTmp = resultDec;
            while (resultDecTmp > 0)
            {
                //use an appropriate string from the array "conversionTable" by index and add it to the top of the result string
                resultHex = resultHex.Insert(0, conversionTable[(int)(resultDecTmp % 16)]);
                resultDecTmp = Math.Floor(resultDecTmp / 16);
            }

            Console.WriteLine("Bin number {0} equal {1} in hex.", binNumber, resultHex);

            EndOfScript();

            // 3.Convert the hexadecimal numbers FA, 2A3E, FFFF, 5A0E9 to binary and decimal numeral systems.
            Console.WriteLine("EX3: Convert the hexadecimal numbers FA, 2A3E, FFFF, 5A0E9 to binary and decimal numeral systems.");
            string[] inputHexaNumbers = { "FA", "2A3E", "FFFF", "5A0E9" };
            string[] conversionTableHexToDec = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F".Split(new char[] { ',' }); //convert numbers 0 .. 15 to string            
            string[] conversionTableHexToBin = "0000,0001,0010,0011,0100,0101,0110,0111,1000,1001,1010,1011,1100,1101,1110,1111".Split(new char[] { ',' });

            foreach (var inputHexNumber in inputHexaNumbers)
            {
                //convert hexa to dec
                double resultDecEx3 = 0;
                for (int i = 0; i < inputHexNumber.Length; i++)
                {
                    //get the index of the every part of the hex number from the "conversionTableEx3" and use it as the integer for conversion
                    //multiply the previous integer (index of hex number value from table) by 16 powered by its position 
                    //2A3E = 2 * 16^3 + A(10) * 16^2 + 3 * 16^1 + E(14) * 16^0 = 8192 + 2560 + 48 + 14 = 10814
                    // 2 -> index of 2 in table is 2
                    // A -> index of A in table is 10 ...
                    // 2 * 16^3 -> 16^3 -> value 2 has position 3 in the hex number 2A3E, 
                    //position is counted from right to left and start with zero
                    // A(10) * 16^2 -> value A is second so 16^2 ...
                    resultDecEx3 +=
                        Array.IndexOf(conversionTableHexToDec, inputHexNumber.Substring(i, 1)) *
                        Math.Pow(16, inputHexNumber.Length - i - 1);
                }
                Console.WriteLine("Hex number {0} equal {1} in dec.", inputHexNumber, resultDecEx3);

                //convert hexa to bin
                //every one character of hexa number is 4 bite number in binary system
                //so it is possible to use two arrays where the index of hexa value in HexToDec array 
                //will be the index of value in HexToBin table
                // hexa 0 = 0000 bin -> index of hexa 0 is 0 and index of bin 0000 is 0
                // hexa A = 1010 bin -> index of hexa A is 9 and index of bin 1010 is 9
                // hexa F = 1111 bin -> index of hexa F is 15 and index of bin 1111 is 15                
                string resultBinEx3 = "";
                string hexStrTmp = "";
                int hexStrTmpIndex = 0;
                for (int i = 0; i < inputHexNumber.Length; i++)
                {
                    hexStrTmp = inputHexNumber.Substring(i, 1);
                    hexStrTmpIndex = Array.IndexOf(conversionTableHexToDec, hexStrTmp);
                    resultBinEx3 += conversionTableHexToBin[hexStrTmpIndex];
                }
                Console.WriteLine("Hex number {0} equal {1} in bin.", inputHexNumber, resultBinEx3);

            }
            EndOfScript();

            //4.Write a program that converts a decimal number to binary one.
            Console.WriteLine("EX4: Convert a positive decimal number to binary.");
            Console.Write("Enter positive decimal number: ");
            string consoleInputEx4 = Console.ReadLine();
            bool consoleInputIsDec = decimal.TryParse(consoleInputEx4, out decimal consoleInputDec);
            if (consoleInputIsDec)
            {
                decimal decTmp = consoleInputDec;
                string decToBinResult = decTmp == 0 ? "0" : "";

                while (decTmp > 0)
                {
                    decToBinResult = decToBinResult.Insert(0, (decTmp % 2).ToString());
                    decTmp = Math.Floor(decTmp / 2);
                }

                Console.WriteLine("{0} in dec = {1} in bin", consoleInputEx4, decToBinResult);
            }
            else
            {
                Console.WriteLine("{0} is not a positive decimal number!!!", consoleInputEx4);
            }

            EndOfScript();
            
            //5.Write a program that converts a binary number to decimal one. 
            Console.WriteLine("EX5: Converts a binary number to a decimal.");
            Console.Write("Enter binary number: ");
            string consoleInputEx5 = Console.ReadLine();
            ulong binToDecResult = 0;
            bool isNumber = false;

            for (int i = 0; i < consoleInputEx5.Length; i++)
            {
                isNumber = int.TryParse(consoleInputEx5.Substring(i, 1), out int consoleInputParseNumber);
                if (isNumber && (consoleInputParseNumber == 0 || consoleInputParseNumber == 1))
                {
                    binToDecResult += (ulong)(consoleInputParseNumber * Math.Pow(2, consoleInputEx5.Length - i - 1));
                }
                else
                {
                    Console.WriteLine("{0} is not binary number!!!", consoleInputEx5);
                    break;
                }
            }
            Console.WriteLine("{0} in bin = {1} in dec", consoleInputEx5, binToDecResult);

            EndOfScript();

            //6.Write a program that converts a decimal number to hexadecimal one.
            Console.WriteLine("EX6: Converts a decimal number to hexadecimal.");
            Console.Write("Enter decimal number: ");
            string consoleInputEx6 = Console.ReadLine();
            bool consoleInputEx6IsNumber = decimal.TryParse(consoleInputEx6, out decimal consoleInputParseToDecimal);

            if (consoleInputEx6IsNumber)
            {
                string decToHexResult = "";
                string[] conversionTableEx6 = ("0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F").Split(new char[] { ',' }); //convert numbers 0 .. 15 to string
                decimal decToHexTmp = consoleInputParseToDecimal;

                while (decToHexTmp > 0)
                {
                    //use an appropriate string from the array "conversionTable" by index and add it to the top of the result string
                    decToHexResult = decToHexResult.Insert(0, conversionTableEx6[(int)(decToHexTmp % 16)]);
                    decToHexTmp = Math.Floor(decToHexTmp / 16);
                }
                Console.WriteLine("{0} in dec = {1} in hex", consoleInputEx6, decToHexResult);
            }
            else
            {
                Console.WriteLine("{0} is not a hex number!!!", consoleInputEx6);
            }

            EndOfScript();

            //7.Write a program that converts a hexadecimal number to decimal one. 
            Console.WriteLine("EX7: Converts a hexadecimal number to a decimal.");
            Console.Write("Enter hexadecimal number: ");
            //convert input to upper, "conversionTable" contains characters in upper format
            string inputConsoleHex = (Console.ReadLine()).ToUpper();
            ulong hexToDecResult = 0;
            bool isHexNumber = true;
            string invalidCharacter = "";
            int invalidCharacterIndex = 0;
            //conversion table / array
            //the decimal value of every possible hexa character is expressed by its position / index in the array 
            string[] conversionTableEx7 = ("0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F").Split(new char[] { ',' });

            //go through an every character of the entered hexa number
            for (int i = 0; i < inputConsoleHex.Length; i++)
            {
                //find index of character in "conversionTable"
                int indexOfString = Array.IndexOf(conversionTableEx7, inputConsoleHex.Substring(i, 1));
                //if the index for the character exists (index must be integer in range 0 .. 15)
                if (indexOfString >= 0 && indexOfString < 16)
                {
                    //calculate a value for character at position i
                    //(value of character) * 16^(position of char from right and from zero)
                    hexToDecResult += (ulong)(indexOfString * Math.Pow(16, inputConsoleHex.Length - i - 1));
                }
                //the index of the character doesn't exist
                else
                {
                    isHexNumber = false;
                    invalidCharacter = inputConsoleHex.Substring(i, 1);
                    invalidCharacterIndex = i + 1;
                    break;
                }
            }

            if (isHexNumber)
            {
                Console.WriteLine("{0} in hex = {1} in dec", inputConsoleHex, hexToDecResult);
            }
            else
            {
                Console.WriteLine("{0} is not a hexadecimal number!!! Invalid char {1} at position {2} " +
                    "from the left side.", inputConsoleHex, invalidCharacter, invalidCharacterIndex);
            }

            EndOfScript();
            

            //8.Write a program that converts a hexadecimal number to binary one. 
            Console.WriteLine("EX8: Converts a hexadecimal number to binary.");
            Console.Write("Enter hexa number: ");
            string consoleInputHexNumber = Console.ReadLine().ToUpper();
            string binResult = "";
            bool inputIsHexNumber = true;
            string[] arrayHexChars = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F".Split(new char[] { ',' });
            string[] arrayHexToBin = ("0000,0001,0010,0011,0100,0101,0110,0111," +
                                      "1000,1001,1010,1011,1100,1101,1110,1111").Split(new char[] { ',' });
            for (int i = 0; i < consoleInputHexNumber.Length; i++)
            {
                int indexOfHexChar = Array.IndexOf(arrayHexChars, consoleInputHexNumber.Substring(i, 1));
                if (indexOfHexChar >= 0)
                {
                    binResult += arrayHexToBin[indexOfHexChar];
                }
                else
                {
                    inputIsHexNumber = false;
                    Console.WriteLine("{0} is not hex number!!! Value {1} at position {2} " +
                        "from left side is invalid", consoleInputHexNumber, consoleInputHexNumber.Substring(i, 1), i + 1);
                    break;
                }
            }
            if (inputIsHexNumber)
            {
                Console.WriteLine("{0} in hex = {1} in bin", consoleInputHexNumber, binResult);
            }

            EndOfScript();
            
            //9.Write a program that converts a binary number to hexadecimal one. 
            Console.WriteLine("EX9: Converts a binary number to hexadecimal.");
            Console.Write("Enter binary number: ");
            string consoleInputBinNumber = Console.ReadLine();            
            string hexResult = "";
            bool inputIsBinNumber = true;
            string[] arrayHexCharsEx9 = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F".Split(new char[] { ',' });
            string[] arrayBinStringsEx9 = ("0000,0001,0010,0011,0100,0101,0110,0111," +
                                      "1000,1001,1010,1011,1100,1101,1110,1111").Split(new char[] { ',' });
            //check if the count of the bits in the bin number is divided by 4 (no remainder)
            //if not, add the zeros to the top of the input bin number so that the count of the bits will be divided by 4 (no remainder)
            if (consoleInputBinNumber.Length < 4)
            {
                consoleInputBinNumber = consoleInputBinNumber.Insert(0, new String('0', 4 - consoleInputBinNumber.Length));
            }
            if (consoleInputBinNumber.Length % 4 != 0 && consoleInputBinNumber.Length > 4)
            {                
                consoleInputBinNumber = consoleInputBinNumber.Insert(0, new String('0', consoleInputBinNumber.Length % 4));             
            }

            //go through the input and select 4-bits parts             
            for (int i = 0; i < consoleInputBinNumber.Length; i += 4)
            {
                //for every part (4-bits starting from left) find index in the array arrayBinStrings
                int indexOfBinString = Array.IndexOf(arrayBinStringsEx9, consoleInputBinNumber.Substring(i, 4));
                //if index exists
                if (indexOfBinString >= 0)
                {
                    //the finded index is used to select the value from the array arrayHexChars and attach it to the result string
                    hexResult += arrayHexCharsEx9[indexOfBinString];
                }
                //if index does not exist
                else
                {
                    inputIsBinNumber = false;
                    Console.WriteLine("{0} is not hex number!!! 4-bits {1} at position {2} " +
                        "from left side are invalid", consoleInputBinNumber, consoleInputBinNumber.Substring(i, 4), i + 1);
                    break;
                }
            }
            if (inputIsBinNumber)
            {
                Console.WriteLine("{0} in bin = {1} in hex", consoleInputBinNumber, hexResult);
            }

            EndOfScript();

            //10.Write a program that converts a binary number to decimal using the Horner scheme.
            Console.WriteLine("EX10: Converts a binary number to decimal using the Horner scheme / algorithm.");
            Console.Write("Enter binary number: ");
            string inputBinConsole = Console.ReadLine();            
            ulong binToDecResultEx10 = 1;
                       
            for (int i = 0; i < inputBinConsole.Length - 1; i++)
            {
                //example how to use Horner scheme
                //1001 = ((1 × 2 + 0) × 2 + 0) × 2 + 1 = 2 × 2 × 2 + 1 = 9 
                int nextBinNumber = int.Parse(inputBinConsole.Substring(i + 1, 1));
                binToDecResultEx10 = binToDecResultEx10 * 2 + (ulong)nextBinNumber;
            }
            Console.WriteLine("{0} in bin = {1} in dec", inputBinConsole, binToDecResultEx10);

            EndOfScript();
            
            //11.Write a program that converts Roman digits to Arabic ones.
            Console.WriteLine("EX11: Program that converts Roman digits to Arabic.");
            Console.Write("Enter number in Roman number system: ");
            string consoleInputRomanNumber = Console.ReadLine().ToUpper();            
            int romanToArabicResult = 0;
            bool isRomanNumber = true;
            int[] romanToArabicNumbers = new int[consoleInputRomanNumber.Length];
            int consoleInputLengthReverse = 0;

            while (consoleInputLengthReverse < consoleInputRomanNumber.Length && isRomanNumber)
            {
                switch (consoleInputRomanNumber.Substring(consoleInputLengthReverse, 1))
                {
                    case "I":
                        romanToArabicNumbers[consoleInputLengthReverse] = 1;
                        break;
                    case "V":
                        romanToArabicNumbers[consoleInputLengthReverse] = 5;
                        break;
                    case "X":
                        romanToArabicNumbers[consoleInputLengthReverse] = 10;
                        break;
                    case "L":
                        romanToArabicNumbers[consoleInputLengthReverse] = 50;
                        break;
                    case "C":
                        romanToArabicNumbers[consoleInputLengthReverse] = 100;
                        break;
                    case "D":
                        romanToArabicNumbers[consoleInputLengthReverse] = 500;
                        break;
                    case "M":
                        romanToArabicNumbers[consoleInputLengthReverse] = 1000;
                        break;
                    default:
                        isRomanNumber = false;
                        break;
                }
                consoleInputLengthReverse++;
            }

            if (isRomanNumber)
            {
                for (int i = 0; i < romanToArabicNumbers.Length - 1; i++)
                {
                    if (romanToArabicNumbers[i] >= romanToArabicNumbers[i + 1])
                    {
                        romanToArabicResult += romanToArabicNumbers[i];
                    }
                    else
                    {
                        romanToArabicResult -= romanToArabicNumbers[i];
                    }
                }
                romanToArabicResult += romanToArabicNumbers[romanToArabicNumbers.Length - 1];
                Console.WriteLine("{0} in Roman = {1} in dec (Arabic)", consoleInputRomanNumber, romanToArabicResult);
            }
            else
            {
                Console.WriteLine("{0} is NOT a Roman number!!!", consoleInputRomanNumber);
            }

            EndOfScript();

            //12.Write a program that converts Arabic digits to Roman ones.            
            Console.WriteLine("EX12: Program that converts Arabic digits to Roman ones.");
            Console.Write("Enter number from 1 to 3999: ");
            string inputConsole = Console.ReadLine();
            
            string[][] romanNumbers = {
                new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" },
                new string[] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" },
                new string[] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" },
                new string[] { "M", "MM", "MMM" }
            };
                        
            string resultInRoman = "";

            for (int i = 0, j = inputConsole.Length - 1; i < inputConsole.Length; i++, j--)
            {
                int inputNumber = int.Parse(inputConsole.Substring(j, 1));
                resultInRoman = resultInRoman.Insert(0, romanNumbers[i][inputNumber - 1]);
            }
            Console.WriteLine("{0} in Arabic = {1} in Roman", inputConsole, resultInRoman);
            EndOfScript();

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
