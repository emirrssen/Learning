namespace Learning.Subjects.AsynchronousAndMultithreadingProgramming._10_WaitHandles_ThreadPool
{
    public class WaitAllExample
    {
        public void Run()
        {
            AutoResetEvent autoResetEvent1 = new(false);
            AutoResetEvent autoResetEvent2 = new(false);
            ManualResetEvent manualResetEvent1 = new(false);
            ManualResetEvent manualResetEvent2 = new(false);

            autoResetEvent1.Set();
            autoResetEvent2.Set();
            manualResetEvent1.Set();
            manualResetEvent2.Set();

            // The program will stop here until all items in the given array are set.
            WaitHandle.WaitAll([
                autoResetEvent1, autoResetEvent2, manualResetEvent1, manualResetEvent2
            ]);

            Console.WriteLine("All wait handles are set.");
            Console.Read();
        }
    }
}


