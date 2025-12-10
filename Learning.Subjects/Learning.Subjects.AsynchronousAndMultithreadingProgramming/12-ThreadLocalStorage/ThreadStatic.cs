namespace Learning.Subjects.AsynchronousAndMultithreadingProgramming._12_ThreadLocalStorage
{
    public class ThreadStatic
    {
        [ThreadStatic]
        static int x = 0;

        public void Run()
        {

            Thread thread1 = new(() =>
            {
                while(x < 10)
                    Console.WriteLine($"Thread 1 : {++x}");
            });

            Thread thread2 = new(() =>
            {
                while (x < 10)
                    Console.WriteLine($"Thread 2 : {++x}");
            });

            Thread thread3 = new(() =>
            {
                while (x < 10)
                    Console.WriteLine($"Thread 3 : {++x}");
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }
    }
}
