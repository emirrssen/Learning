namespace Learning.Subjects.AsynchronousAndMultithreadingProgramming._12_ThreadLocalStorage
{
    public class ThreadLocal
    {
        ThreadLocal<int> x = new(() => 0);

        public void Run()
        {

            Thread thread1 = new(() =>
            {
                while (x.Value < 10)
                    Console.WriteLine($"Thread 1 : {++x.Value}");
            });

            Thread thread2 = new(() =>
            {
                while (x.Value < 10)
                    Console.WriteLine($"Thread 2 : {++x.Value}");
            });

            Thread thread3 = new(() =>
            {
                while (x.Value < 10)
                    Console.WriteLine($"Thread 3 : {++x.Value}");
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }
    }
}


