using System.Threading;

namespace MultiThreading
{
    class Programm
    {
        static void Main(string[] args)
        {
            var timer_thread = new Thread(UpdateHeaderTime);
            timer_thread.Start();

            Console.WriteLine("1231231213");
            Console.ReadLine();
        }

        private static void UpdateHeaderTime()
        {
            while (true)
            {
                Console.Title = DateTime.Now.ToString("HH:mm:ss.ffff");
            }
        }
    }
}
