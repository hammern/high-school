using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Time watch;
            int inputHour;
            int inputMinute;
            watch = new Time();
            Console.Write("Enter the hour (0..23): ");
            inputHour = int.Parse(Console.ReadLine());
            Console.Write("Enter the minute (0..59): ");
            inputMinute = int.Parse(Console.ReadLine());
            watch.SetTime(inputHour, inputMinute);
            Console.WriteLine("The time is: {0}", watch.GetTime());
            if (inputMinute >= 60)
            {
                inputHour++;
                inputMinute = inputMinute - 60;
                if (inputHour == 24)
                {
                    inputHour = 0;
                }
            }
            Console.WriteLine("The updated time is: {0}:{1}", inputHour, watch.Increment());
            Console.Read();
        }
    }
    public class Time
    {
        private int hour = 0;
        // Stores the houres
        private int minute = 0;
        // Stores the minutes
        // Sets the time with new values
        public void SetTime(int h, int m)
        {
            hour = h;
            minute = m;
        }
        // Returns a string representation of the time
        public string GetTime()
        {
            return hour + ":" + minute;
        }
        public void Increment()
        {
            minute += 1;
        }
    }
}
