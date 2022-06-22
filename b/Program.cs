using System;
using System.Collections.Generic;
using System.Text;

namespace b
{
    class Program
    {
        static string code = "";

        static List<int> stacks = new List<int>();

        static int highlightedStack = 0;

        static int dueToss = 0;

        static int ignores = 0;

        static int line = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Input your B code.");
            code = Console.ReadLine();
            Console.WriteLine("\n");

            stacks.Add(0);
            string[] lines = code.Split("B");

            while (line < lines.Length) {
                string s = lines[line];
                if (ignores == 0)
                {
                    if (allCharactersSame(s))
                    {
                        switch (s.Length)
                        {
                            case 1:
                                stacks[highlightedStack] += 1;
                                break;
                            case 2:
                                if (stacks[highlightedStack] > 0)
                                {
                                    stacks[highlightedStack] -= 1;
                                    dueToss += 1;
                                }
                                break;
                            case 3:
                                if (highlightedStack > 0)
                                {
                                    highlightedStack -= 1;
                                    stacks[highlightedStack] += dueToss;
                                    dueToss = 0;
                                }
                                break;
                            case 4:
                                if (highlightedStack - 1 < stacks.Count)
                                {
                                    highlightedStack += 1;
                                    stacks[highlightedStack] += dueToss;
                                    dueToss = 0;
                                }
                                break;
                            case 5:
                                stacks.Add(0);
                                break;
                            case 6:
                                if (stacks[highlightedStack] != 0)
                                {
                                    ignores += 2;
                                }
                                break;
                            case 7:
                                switch (stacks[highlightedStack])
                                {
                                    case 1:

                                        try
                                        {
                                            stacks[highlightedStack] = (int)Console.ReadLine()[0];
                                        }
                                        catch (ArgumentNullException)
                                        { }
                                        break;
                                    case 2:
                                        ignores += stacks[highlightedStack];
                                        stacks[highlightedStack] = 0;
                                        break;
                                    case 3:
                                        if (stacks[highlightedStack] != 0)
                                        {
                                            line -= 3;
                                        }
                                        break;
                                    default:
                                        Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(stacks[highlightedStack]) }));
                                        stacks[highlightedStack] = 0;
                                        break;
                                }
                                break;
                        }
                    }
                } else { ignores -= 1; }
                line += 1;
            }
            Console.ReadLine();
        }
        static bool allCharactersSame(string s)
        {
            int n = s.Length;
            for (int i = 1; i < n; i++)
                if (s[i] != s[0])
                    return false;

            return true;
        }
    }
}
