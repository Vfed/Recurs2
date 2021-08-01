using System;

namespace Recurs2
{
    class Program
    {
        
        static string RecursString(string Code)
        {
            if(Code.Length > 0)
            {
                if (Code.Length == 2 && Code[1] == ' ') 
                {
                    return " "; 
                }

                if (Code[0] == '}' || Code[0] == ']' || Code[0] == ')')
                {
                    return Code;
                }

                if (Code.Length > 1)
                {
                    if ((Code[0] == '{' && Code[1] == '}') || (Code[0] == '[' && Code[1] == ']') || (Code[0] == '(' && Code[1] == ')'))
                    {
                        return RecursString(Code.Substring(2));
                    }
                    switch (Code[0])
                    {
                        case '{' when Code[1] != ']' && Code[1] != ')':
                            return RecursString(Code[0] + RecursString(Code.Substring(1)));
                        case '[' when Code[1] != '}' && Code[1] != ')':
                            return RecursString(Code[0] + RecursString(Code.Substring(1)));
                        case '(' when Code[1] != ']' && Code[1] != '}':
                            return RecursString(Code[0] + RecursString(Code.Substring(1)));

                        default:
                            return " ";
                    }
                }
                else 
                {
                    return " ";
                }
            }
            return Code;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter String : ");
                string SomeCode = Console.ReadLine();
                SomeCode = RecursString(SomeCode);
                if (SomeCode.Length == 0)
                {
                    Console.WriteLine("is ok " + SomeCode);
                }
                else
                {
                    Console.WriteLine("not ok " + SomeCode);
                }
                if (Console.ReadKey().Key == ConsoleKey.Escape) {
                    return;
                };
            }
        }
    }
}
