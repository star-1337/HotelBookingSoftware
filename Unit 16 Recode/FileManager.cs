using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Unit_16_Recode
{
    class FileManager
    {
        int counter = 0;


        public void FormatOutput(Data D)
        {
            string longest = D.ReturnData().OrderByDescending(s => s.Length).First();
            int length = longest.Length;
            for (int i = 0; i < D.ReturnData().Length; i++)
            {
                string value = " ";
                if (i == 0)
                    value = "Room Number"; ;
                if (i == 1)
                    value = "Name";
                if (i == 2)
                    value = "Address:";
                if (i == 3)
                    value = "Phone Number";
                if (i == 4)
                    value = "DOB";

                Console.Write(value.PadRight(12));
                Console.Write("|");
                Console.Write(D.ReturnData()[i].Trim().PadRight(length));
                Console.WriteLine("|");
            }
        }

        public void FormatFile() // functions deletes empty lines within the file
        {
            string[] roomData = File.ReadAllLines("HotelData.txt");
            int count = 0;
            foreach (string s in roomData)
            {
                if(s == "") // if the string is empty 
                {
                    roomData = roomData.Where(x => !string.IsNullOrEmpty(x)).ToArray(); // removes the empty line from the array
                    count++;
                }
                File.WriteAllLines("HotelData.txt", roomData); // writes new clean data to file
            }
        }

        public string FindRoom(int room_no)
        {
            counter = 0;
            string[] roomData = File.ReadAllLines("HotelData.txt");
            foreach (string s in roomData)
            {
                if (s == "")
                {
                    counter++;
                    continue;
                }
                string[] data = s.Split(","); //splits each line into stringd

                if (Convert.ToInt32(data[0]) == room_no) // if the users room number equals the room number within the file 
                {
                    return (roomData[counter]); // returns the data from the line 
                }

                counter++;                
            }
            return null;
        }
        public Data Read(int room_no)
        {
            if (FindRoom(room_no) != null) //Checks if line is not empty
            {
                //if the line is not empty, reads file and then splits the room number line through the find room function
                string[] roomDataStr = File.ReadAllLines("HotelData.txt")[counter].Split(",");
                return new Data(Convert.ToInt32(roomDataStr[0]), roomDataStr[1], roomDataStr[2], roomDataStr[3], roomDataStr[4]); // Returns data from file in the class
            }

            else // if the line is empty 
            {
                Console.WriteLine("Room is empty.");
                Console.ReadKey();
                return new Data();
            }
        }

        public Data WriteData()
        {
            //taking users input and storing into an array and storing in class
            string[] inputData = new string[5];

            Console.WriteLine("Name:");
            inputData[1] = Console.ReadLine();

            Console.WriteLine("Address:");
            inputData[2] = Console.ReadLine();

            Console.WriteLine("Phone number:");
            inputData[3] = Console.ReadLine();

            Console.WriteLine("DOB:");
            inputData[4] = Console.ReadLine();

           return new Data(Convert.ToInt32(inputData[0]), inputData[1], inputData[2], inputData[3], inputData[4]);
        }

        public void Write(int room_no)
        {
            string[] roomData = File.ReadAllLines("HotelData.txt"); // reading data from file and storing into an array

            if (FindRoom(room_no) == null) //checks if the line in the file is available 
            {
                Data D = WriteData();
                string inputStr = String.Join(", ", D.ReturnData()); // joining the array into a string via commas

                File.AppendAllText("HotelData.txt", inputStr); // writing the users input onto the next available line 
            }
            else
                Console.WriteLine("Room is booked"); // if the line doesnt contains data, outputs this
        }

        public void Edit(int room_no)
        {
            string[] roomData = File.ReadAllLines("HotelData.txt"); //reading file 

            if (FindRoom(room_no) != null)
            {
                Console.Clear();
                FormatOutput(Read(room_no)); // outputs data in a clean format
                Console.WriteLine("-------------");//
                Console.WriteLine("NEW ROOM DATA");//
                Console.WriteLine("-------------");//
                Data D = WriteData(); // passing in data
                string inputStr = String.Join(", ", D.ReturnData()); // joins array into a string (seperated by commas)
                roomData[counter] = inputStr;

                File.WriteAllLines("HotelData.txt", roomData); // write data to file 
                Console.WriteLine("Edit Successful");
            }

            else
                Console.WriteLine("Room is empty!");
        }

        public void Checkout(int room_no)
        {
            string[] roomData = File.ReadAllLines("HotelData.txt"); // reading lines 
            FormatOutput(Read(room_no));
            FindRoom(room_no); // returns room line 
            roomData[counter] = null; // sets array to blank
            roomData = roomData.Where(x => !string.IsNullOrEmpty(x)).ToArray(); // code from stackoverflow (empties the array)
            File.WriteAllLines("HotelData.txt", roomData); // writes to file 
            Console.WriteLine("Checkout complete"); // output for the user 
        }
    }
}
