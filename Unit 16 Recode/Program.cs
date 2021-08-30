using System;
using System.Threading;
using System.Linq;

namespace Unit_16_Recode
{
    class Program
    {
        static int GetRoomNo() 
        {
            Start:
            Console.WriteLine("Enter Room number");
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                Console.Clear();
                goto Start;
            }
        }

        static void Main(string[] args)
        {            
            Console.WriteLine("Hotel Booking Software");
            bool loopHandle = false;
            while (!loopHandle)
            { 
                Console.WriteLine("Select: \n1)Load Data\n2)Save Data\n3)Add Rooms\n4)Reserve Room\n5)Checkout Room\n6)Exit");
                string operation = Console.ReadLine();

                FileManager fm = new FileManager();
                fm.FormatFile();

                switch (operation)
                {
                    case "1":
                        Console.Clear();
                        Data D = fm.Read(GetRoomNo());
                        Console.Clear();
                        fm.FormatOutput(D);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        fm.Edit(GetRoomNo());
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        fm.Write(GetRoomNo());
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        fm.Write(GetRoomNo());
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5":
                        Console.Clear();
                        fm.Checkout(GetRoomNo());
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "6":
                        loopHandle = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    
                }
            }
        }
    }
}
