namespace Learning.AsynchronousAndMultithreadingProgramming._09_Signalling
{
    public class AutoResetEventExample
    {
        public void Run()
        {
            AutoResetEvent autoResetEvent = new(false);
            int counter = 0;

            Thread thread1 = new(() =>
            {
                while (counter < 10)
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Thread 1 : {++counter}");
                }

                autoResetEvent.Set();
            });

            Thread thread2 = new(() =>
            {
                autoResetEvent.WaitOne();

                while (counter < 20)
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Thread 2 : {++counter}");
                }

                autoResetEvent.Set();
            });

            Thread thread3 = new(() =>
            {
                autoResetEvent.WaitOne();

                while (counter++ < 30)
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Thread 3 : {++counter}");
                }

                autoResetEvent.Set();
            });

            thread1.Start();
            thread3.Start();
            thread2.Start();
        }
    }
}
