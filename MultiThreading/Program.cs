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
            //timer_thread.IsBackground = true; // сделать поток фоновым
            timer_thread.Name = "Поток часов";
            timer_thread.Priority = ThreadPriority.AboveNormal;
            //timer_thread.IsAlive
            

            timer_thread.Start();
            var timer_tid = timer_thread.ManagedThreadId;
            Console.WriteLine("Timer thread id:{0}", timer_tid);

            var main_thread = Thread.CurrentThread;
            Console.WriteLine("Основной поток имеет id:{0}", main_thread.ManagedThreadId);

            for (var i = 0; i < 30; i++)
            {
                Console.WriteLine("Действие {0} в основном потоке", i);
                Thread.Sleep(50);
            }

            Console.WriteLine("Для выхода нажмите Enter");
            Console.ReadLine();

            // остановка потока часов

            __CanTimeUpdate = false;

            if (!timer_thread.Join(1000))
            {
                Console.WriteLine("Ожидание завершения работы потока часов превысило таймаут в 1000 мс");
                timer_thread.Interrupt();
                timer_thread.Join();
            }

            //timer_thread.Interrupt();
            //timer_thread.Abort(); // от этого метода отказались в силу его опасности

            Console.WriteLine("Работа программы завершена");
            Console.ReadLine();
        }

        private static bool __CanTimeUpdate = true;
        private static void UpdateHeaderTime()
        {
            var timer_thread = Thread.CurrentThread;

            Console.WriteLine("Поток обновления часов запущен в потоке с ID:{0}", timer_thread.ManagedThreadId);

            try
            {
                while (__CanTimeUpdate)
                {
                    Console.Title = DateTime.Now.ToString("HH:mm:ss.fff");
                    Thread.Sleep(500);      // Метод ставит поток на паузу в планировщике потоков ОС
                    //Thread.SpinWait(10000); // Выполняет указанное количество пустых циклов процессора - требуется тогда, когда необходимо чуть-чуть приостановить программу
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Поток был прерван с помощью вызова Abort()");
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Поток был прерван с помощью вызова Interrupt()");
            }

            Console.WriteLine("Поток обновления часов завершён ID:{0}", timer_thread.ManagedThreadId);
        }
    }
}
