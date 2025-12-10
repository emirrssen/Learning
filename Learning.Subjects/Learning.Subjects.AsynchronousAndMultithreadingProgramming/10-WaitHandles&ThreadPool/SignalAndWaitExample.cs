namespace Learning.Subjects.AsynchronousAndMultithreadingProgramming._10_WaitHandles_ThreadPool
{
    public class SignalAndWaitExample
    {
        public void Run()
        {
            AutoResetEvent autoResetEvent1 = new(false);
            AutoResetEvent autoResetEvent2 = new(false);

            autoResetEvent1.Set();
            // The program will stop here until the other auto-reset event is set.
            Console.WriteLine("Waiting...");
            Thread.Sleep(1000);
            autoResetEvent2.Set();

            WaitHandle.SignalAndWait(autoResetEvent1, autoResetEvent2);

            Console.WriteLine("Both auto-reset events have been set.");
            Console.Read();
        }
    }
}
