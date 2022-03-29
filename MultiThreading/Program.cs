using System.Threading;
using System.Diagnostics;

namespace MultiThreading
{
    class Programm
    {
        static void Main(string[] args)
        {
            //Process cmd_process = Process.Start("cmd.exe");
            //Process calc_process = Process.Start("cmd.exe");
            Process current = Process.GetCurrentProcess();
            current.PriorityClass = ProcessPriorityClass.AboveNormal;
            //current.Kill();
            //current.CloseMainWindow();
            Console.WriteLine("Current PID:{0}", current.Id);

            // Способы организации многопоточности
            // 1. Корпоративная многопоточность
            // 2. Вытесняющая многопоточность

            var timer_thread = new Thread(UpdateHeaderTime);
            timer_thread.IsBackground = true; // сделать поток фоновым
            timer_thread.Name = "Поток часов";
            timer_thread.Priority = ThreadPriority.AboveNormal;
            //timer_thread.IsAlive
            

            timer_thread.Start();
            var timer_tid = timer_thread.ManagedThreadId;
            Console.WriteLine("Timer thread id:{0}", timer_tid);

            Console.WriteLine("1231231213");
            Console.ReadLine();
        }

        private static void UpdateHeaderTime()
        {
            while (true)
            {
                Console.Title = DateTime.Now.ToString("HH:mm:ss.fff");
                Thread.Sleep(100);
            }
        }
    }
}
