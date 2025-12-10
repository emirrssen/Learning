namespace Learning.Subjects.AsynchronousAndMultithreadingProgramming._10_WaitHandles_ThreadPool
{
    public class WaitAnyExample
    {
        public void Run()
        {
            AutoResetEvent autoResetEvent1 = new(false);
            AutoResetEvent autoResetEvent2 = new(false);
            ManualResetEvent manualResetEvent1 = new(false);
            ManualResetEvent manualResetEvent2 = new(false);

            autoResetEvent1.Set();

            // The program will stop here until one item in the given array is set.
            WaitHandle.WaitAny([
                autoResetEvent1, autoResetEvent2, manualResetEvent1, manualResetEvent2
            ]);

            Console.WriteLine("One wait handle is set.");
            Console.Read();
        }
    }
}
