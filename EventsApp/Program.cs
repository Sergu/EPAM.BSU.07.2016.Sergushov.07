using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events;

namespace EventsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomTimer timerFirst = new CustomTimer();
            CustomTimer timerSec = new CustomTimer();
            TimerListener listener = new TimerListener(timerFirst);
            listener.Register(timerSec);
            Console.WriteLine("Enter time for first timer:");
            int time;
            string inputStr = "a";
            while (!int.TryParse(inputStr, out time))
            {
                Console.Write("Enter time(seconds) for first timer:");
                inputStr = Console.ReadLine();
            }
            timerFirst.TimerStart(time);
            inputStr = "a";
            while (!int.TryParse(inputStr, out time))
            {
                Console.Write("Enter time(seconds) for second timer:");
                inputStr = Console.ReadLine();
            }
            timerSec.TimerStart(time);
            foreach (TimerEventArgs arg in listener.GetAllTimersNotifications())
            {
                Console.WriteLine("Listener:  Elapsed seconds : {0} ", arg.ElapsedTime);
            }
            Console.ReadLine();
        }
    }
}
