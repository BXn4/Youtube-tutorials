using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Console_keyboard_spammer
{
    class Program
    {
        static void Main(string[] args)
        {
            int interval = 2000;
            int duration = 5;
            int o = 0;
            int tC = 0;
            var words = new List<string>
            {

            };
        top:
            Console.Clear();
            Console.WriteLine("Please select a option:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t[1] > Start");
            Console.WriteLine("\t[2] > Setup the bot");
            Console.WriteLine("\t[3] > Exit");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n> ");
            string option = Console.ReadLine();
            if (option == "1")
            {
                while (o != duration)
                {
                    Thread.Sleep(interval);
                    if (words.Count == 1)
                    {
                        Console.Write("\n[Done]");
                        Console.Write($"Entered word: {words[0]}");
                        SendKeys.SendWait(words[0]);
                        SendKeys.SendWait("{ENTER}");
                        o++;
                    }
                    else
                    {
                        Console.Write("\n[Done]");
                        try
                        {
                            Console.Write($"Entered word: {words[tC]}");
                            SendKeys.SendWait(words[tC]);
                            SendKeys.SendWait("{ENTER}");
                            tC++;
                        }
                        catch
                        {
                            Console.Write($"\n--{o + 1}--");
                            tC = 0;
                            o++;
                        }
                    }
                }
            }
                if (option == "2")
                {
                    Console.Clear();
                    words.Clear();
                    Console.Write("\n Do you want to use multiple lines? (Y/N) : ");
                    string multiplelines = Console.ReadLine();
                    if (multiplelines == "Y")
                    {
                        Console.WriteLine("Please enter the text (max 10), then press enter. When you done type: IMDONE");
                        for (int i = 1; i < 11;)
                        {
                            Console.Write($"\nPlease enter the text number {i}: ");
                            string text = Console.ReadLine();
                            if (text == "IMDONE")
                            {
                                break;
                            }
                            else
                            {
                                words.Add(text);
                                i++;
                            }
                        }
                    }
                    if (multiplelines == "N")
                    {
                        Console.Write("Please enter the text: ");
                        string textentered = Console.ReadLine();
                        words.Add(textentered);
                    }
                    else
                    {

                    }
                interval:
                    Console.Write("Please enter the interval (1-9999ms): ");
                    string intervalRl = Console.ReadLine();
                    try
                    {
                        int numbercheck = int.Parse(intervalRl);
                        if (numbercheck > 0 && numbercheck < 10000)
                        {
                            interval = numbercheck;
                        }
                        else
                        {
                            Console.WriteLine("The number is not between 1 and 9999!");
                            goto interval;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Not a number!");
                        goto interval;
                    }
                    Console.Write("Please enter the duration (x times): ");
                    string durationRl = Console.ReadLine();
                    int durationcheck = 0;
                    try
                    {
                        durationcheck = int.Parse(durationRl);
                    }
                    catch
                    {

                    }
                    duration = durationcheck;
                    Console.WriteLine("Everything is done! Press any key to go back.");
                    Console.ReadKey();
                    goto top;
                }
                if (option == "3")
                {
                    Application.Exit();
                }
            }
        }
    }
