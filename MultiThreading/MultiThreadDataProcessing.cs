namespace MultiThreading
{
    public static class MultiThreadDataProcessing
    {
        public static void Run()
        {
            const int messages_count = 1000;
            var messages = new string[messages_count];

            for (var i = 0; i < messages_count; i++)
                messages[i] = $"Message-{i + 1}";

            for (var i = 0; i < messages_count; i++)
            {
                var i0 = i;
                //var thread = new Thread(() => ProcessMessage(messages[i])); // () => ProcessMessage(messages[i]) - замыкание на переменной i внутри лямбда-выражения
                var thread = new Thread(() => ProcessMessage(messages[i0])); 
                thread.Start();
            }
        }

        private static void ProcessMessage(string Message)
        {
            //var thread_id = Thread.CurrentThread.ManagedThreadId;
            var thread_id = Environment.CurrentManagedThreadId;

            Console.WriteLine("[tid:{0}] Обработка сообщения {1} начата...", thread_id, Message);

            Thread.Sleep(500);

            Console.WriteLine("[tid:{0}] Обработка сообщения {1} завершена", thread_id, Message);
        }
    }
}
