namespace Learning.Subjects.AsynchronousAndMultithreadingProgramming._15_TaskFactory_TaskScheduler_TaskCompletionSource;

public class TaskFactory
{
    private readonly Dictionary<MethodToRun, Action> _methodMap = new()
    {
        { MethodToRun.StartNew, RunStartNew },
        { MethodToRun.ContinueWhenAll, RunContinueWhenAll },
        { MethodToRun.ContinueWhenAny, RunContinueWhenAny },
    };
    
    public void Run(MethodToRun methodToRun)
        => _methodMap[methodToRun](); 

    private static void RunStartNew()
    {
        System.Threading.Tasks.TaskFactory factory = new();
        factory.StartNew(() =>
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i);
        });
    }

    private static void RunContinueWhenAll()
    {
        System.Threading.Tasks.TaskFactory factory = new();
        
        Task task1 = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine($"Task 1: {i}");
        });
        
        Task task2 = Task.Run(() =>
        {
            for (int i = 10; i < 20; i++)
                Console.WriteLine($"Task 2: {i}");
        });
        
        Task task3 = Task.Run(() =>
        {
            for (int i = 20; i < 30; i++)
                Console.WriteLine($"Task 3: {i}");
        });
        
        Task task = factory.ContinueWhenAll(new[] { task1, task2, task3 }, (completedTask) =>
        {
            Console.WriteLine("All done...");
        });
    }

    private static void RunContinueWhenAny()
    {
        System.Threading.Tasks.TaskFactory factory = new();
        
        Task task1 = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine($"Task 1: {i}");
        });
        
        Task task2 = Task.Run(() =>
        {
            Task.Delay(5000);
            for (int i = 10; i < 20; i++)
                Console.WriteLine($"Task 2: {i}");
        });
        
        Task task3 = Task.Run(() =>
        {
            Task.Delay(5000);
            for (int i = 20; i < 30; i++)
                Console.WriteLine($"Task 3: {i}");
        });
        
        Task task = factory.ContinueWhenAny(new[] { task1, task2, task3 }, (completedTask) =>
        {
            Console.WriteLine("All done...");
        });
    }

    public enum MethodToRun
    {
        None = 0,
        StartNew = 1,
        ContinueWhenAll = 2,
        ContinueWhenAny = 3
    }
}