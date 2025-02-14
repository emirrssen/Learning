namespace Learning.AsynchronousAndMultithreadingProgramming._10_WaitHandles_ThreadPool
{
    public class WaitHandlesWithThreadPoolExample
    {
        public void Run()
        {
            // Program started.
            Console.WriteLine("Program started!");

            AutoResetEvent autoResetEvent = new(false);

            // Parameters are given below order by passed:
            // 1st Parameter - Wait Handle to be used.
            // 2nd Parameter - Worker method to be ran.
            // 3rd Parameter - Worker method's first parameter to be used as state.
            // 4th Parameter - Timeout value: If the given amount of time passes, execute automatically without waiting for the auto-reset event to be set.
            // 5th Parameter - Try executing more than once: If the given amount of time passes and the worker method has not executed, try again.
            // In summary, worker method will execute when the auto-reset event is set.
            RegisteredWaitHandle registeredWaitHandle = ThreadPool.RegisterWaitForSingleObject(autoResetEvent, WorkerMethod, "Work 1", -1, true);

            // Set the auto-reset event 3 seconds after the program starts.
            Thread.Sleep(3000);
            autoResetEvent.Set();

            // Resources must be released after worker method's job is done.
            registeredWaitHandle.Unregister(autoResetEvent);

            Console.Read();
        }

        public void WorkerMethod(object state, bool timedOut)
        {
            string name = (string)state;
            Console.WriteLine($"{name} is started!");
            Thread.Sleep(5000);
            Console.WriteLine($"{name} is ended!");
        }
    }
}






