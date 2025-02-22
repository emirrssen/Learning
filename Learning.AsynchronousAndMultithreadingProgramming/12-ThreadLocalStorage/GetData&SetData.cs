namespace Learning.AsynchronousAndMultithreadingProgramming._12_ThreadLocalStorage
{
    public class GetData_SetData
    {
        LocalDataStoreSlot localDataStoreSlote = Thread.GetNamedDataSlot("x");
        int x
        {
            get
            {
                var data = (int?)Thread.GetData(localDataStoreSlote);
                return data is null ? 0 : data.Value;
            }
            set => Thread.SetData(localDataStoreSlote, value);
        }

        public void Run()
        {

            Thread thread1 = new(() =>
            {
                while (x < 10)
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
