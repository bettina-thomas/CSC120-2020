using System;

namespace LogicGate
{
    using System;
    /*The code from Github contains an assortment different gates ranging from simple to complex. These gates are combined to form other gates to perform
     * certain arthimetic functions. The adder for example, adds bits together and performs a carry whenever necessary.

    */
    //The Program takes user input and tests different logic gates
        class Program
        {
            static void Main()
            {
                Console.WriteLine("Enter 1 or 0");
                int input1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter 1 or 0");
                int input2 = Convert.ToInt32(Console.ReadLine());

                bool ans = Andgate(input1, input2);
                Console.WriteLine("And: " + ans);
                ans = Orgate(input1, input2);
                Console.WriteLine("Or: " + ans);
                ans = Nand(input1, input2);
                Console.WriteLine("Nand: " + ans);
                ans = Xor(input1, input2);
                Console.WriteLine("Xor: " + ans);
                ans = Xnor(input1, input2);
                Console.WriteLine("Xnor: " + ans);
            }
            static bool Andgate(int input1, int input2)
            {
                if (input1 == input2)
                {
                    if (input1 == 0)
                    {
                        return false;
                    }
                    return true;
                }
                else
                    return false;
            }
            static bool Orgate(int input1, int input2)
            {
                if (input1 != input2)
                {
                    return true;
                }
                return false;
            }
            static bool Not(int input1)
            {
                if (input1 == 0)
                {
                    return true;
                }
                else return false;

            }
            static bool Nand(int input1, int input2)
            {
                bool val = Andgate(input1, input2);
                if (val == false)
                {
                    return true;
                }
                else return false;
            }
            static bool Nor(int input1, int input2)
            {
                bool val = Orgate(input1, input2);
                if (val == false)
                {
                    return true;
                }
                else return false;
            }
            static bool Xnor(int input1, int input2)
            {
                if (input1 == input2)
                {
                    return true;
                }
                else return false;
            }
            static bool Xor(int input1, int input2)
            {
                if (input1 == input2)
                {
                    return false;
                }
                else return true;
            }
        }
    

}
