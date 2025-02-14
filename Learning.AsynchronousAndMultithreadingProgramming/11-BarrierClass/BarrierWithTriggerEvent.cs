namespace Learning.AsynchronousAndMultithreadingProgramming._11_BarrierClass
{
    public class BarrierWithTriggerEvent
    {
        public void Run()
        {
            Barrier barrier = new(3, _ => Console.WriteLine("All signals were received from all threads."));

            Thread thread1 = new(() =>
            {
                for (int i = 0; i < 5; i++)
                    Console.WriteLine($"Thread 1.1 - {i}");

                barrier.SignalAndWait();

                for (int i = 0; i < 3; i++)
                    Console.WriteLine($"Thread 1.2 - {i}");
            });

            Thread thread2 = new(() =>
            {
                for (int i = 0; i < 3; i++)
                    Console.WriteLine($"Thread 2.1 - {i}");

                barrier.SignalAndWait();

                for (int i = 0; i < 2; i++)
                    Console.WriteLine($"Thread 2.2 - {i}");
            });

            Thread thread3 = new(() =>
            {
                for (int i = 0; i < 4; i++)
                    Console.WriteLine($"Thread 3.1 - {i}");

                barrier.SignalAndWait();

                for (int i = 0; i < 5; i++)
                    Console.WriteLine($"Thread 3.2 - {i}");
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }
    }
}
