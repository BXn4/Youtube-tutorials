using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Spammer_simple___BXn4
{

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var BXn4text = new List<string>
            {
  " ______  __      _  _   ",
 "| __ ) \\/ /_ __ | || |  ",
 "|  _ .\\  /| '_ \\| || |_ ",
 "| |_) /  \\| | | |__   _|",
 "|____/_/\\_\\_| |_|  |_|  "       
                          
            };
            var textlist = new List<string>
            {
                "IT'S WORKING!"
            };
            int interval = 2000;
            int duration = 20;
            int o = 0;
            int tC = 0;
            top:
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < BXn4text.Count; i++)
            {
                Console.WriteLine($"{BXn4text[i]}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPlease select a option:");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\t[1] > Start");
            Console.WriteLine("\t[2] > Setup the bot");
            Console.WriteLine("\t[3] > Load settings from file");
            Console.WriteLine("\t[4] > Save settings to file");
            Console.WriteLine("\t[5] > Exit");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n > ");
            string option = Console.ReadLine();
            if(option == "1")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Starting... ");
                using (var progress = new ProgressBar())
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        progress.Report((double)i / 100);
                        Thread.Sleep(50);
                    }
                }
                Console.WriteLine("Running!");
                while (o != duration)
                {
                    Thread.Sleep(interval);
                    if(textlist.Count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("\n[✓] ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"Entered word: {textlist[0]}");
                        SendKeys.SendWait(textlist[0]);
                        SendKeys.SendWait("{ENTER}");
                        o++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("\n[✓] ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        try {
                            Console.Write($"Entered word: {textlist[tC]}");
                            SendKeys.SendWait(textlist[tC]);
                            SendKeys.SendWait("{ENTER}");
                            tC++;
                        }
                        catch
                        {
                            Console.Write($"--{o + 1}--");
                            tC = 0;
                            o++;
                        }
                            }
                        }
                o = 0;
                    }
            if (option == "2")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                for (int i = 0; i < BXn4text.Count; i++)
                {
                    Console.WriteLine($"{BXn4text[i]}");
                }
                textlist.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nHere you can add multiple lines (max 10), and setup the interval.\nPress enter to add new line.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nDo you want to use multiple text? (Y/N) : ");
                string multiplelines = Console.ReadLine();
                if(multiplelines == "Y" || multiplelines == "y")
                {
                    Console.WriteLine("\n");
                    for (int i = 1; i < 11;)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Enter the text {i}: (type IMDONE, when you done)");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("> ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string text = Console.ReadLine();
                        textlist.Add(text);
                        //Console.WriteLine($"{textlist[i - 1]}"); check only
                        i++;
                        if(text == "IMDONE")
                        {
                            break;
                        }
                    }
                    goto interval;
                }
                if (multiplelines == "N" || multiplelines == "n")
                {
                    Console.WriteLine("\nYou can write now.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string text = Console.ReadLine();
                    textlist.Add(text);
                    goto interval;
                }
                else
                {
                    //multiplelines = N;
                    Console.WriteLine("\nYou can write now.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string text = Console.ReadLine();
                    textlist.Add(text);
                    goto interval;
                }
            interval:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nNow please type the interval. (1-99999ms)");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.White;
                string intervalRL = Console.ReadLine();
                try
                {
                    int intervalcheck = Convert.ToInt32(intervalRL);
                    if(intervalcheck > 0 && intervalcheck < 100000)
                    {
                        interval = intervalcheck;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The number is not between 1 and 99999!");
                        goto interval;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a number!");
                    goto interval;
                }
            duration:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPlease enter duration times (1-99999)");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.White;
                string durationtime = Console.ReadLine();
                try
                {
                    int durationcheck = Convert.ToInt32(durationtime);
                    if (durationcheck > 0 && durationcheck < 100000)
                    {
                        duration = durationcheck;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The number is not between 1 and 99999!");
                        goto duration;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a number!");
                    goto duration;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nSetup is done! Press any key to go back.");
                Console.ReadKey();
            }
            if (option == "3")
            {
                OpenFileDialog fd = new OpenFileDialog();
                var loadedelements = new List<string>
                {
                    
                };
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    using (var reader = new StreamReader(fd.FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            loadedelements.Add(line);
                            Console.WriteLine(line); 
                        }
                    }
                    for (int i = 0; i < loadedelements.Count; i++)
                    {
                        textlist.Add(loadedelements[i]);
                        string inter = (loadedelements[0]);
                       interval = int.Parse(inter);
                       string dur = (loadedelements[1]);
                       duration = int.Parse(dur);
                       //loadedelements.Remove(loadedelements[0]);
                       //loadedelements.Remove(loadedelements[1]);
                       textlist.Remove(textlist[0]);
                    }
                }
            }
            if (option == "4")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "spam.txt";
                save.Filter = "Text File | *.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(save.OpenFile());
                    writer.WriteLine(interval);
                    writer.WriteLine(duration);
                    for (int i = 0; i < textlist.Count; i++)
                    {
                        writer.WriteLine(textlist[i].ToString());
                    }
                    writer.Dispose();
                    writer.Close();
                }
            }
            if (option == "5")
            {
                Console.Clear();
            }
            else
            {
                for (int i = 0; i < textlist.Count; i++)
                {
                    //MessageBox.Show($"{textlist.Count}");
                }
                Console.Clear();
                goto top;
            }
        }
        
    }
}
