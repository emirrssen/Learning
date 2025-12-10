namespace Learning.Subjects.AsynchronousAndMultithreadingProgramming._13_TaskClass;

public class CreatingInstance
{
    public void Run(InstanceCreatingType type)
    {
        switch (type)
        {
            case InstanceCreatingType.NewTask:
                NewTask();
                break;
            case InstanceCreatingType.TaskRun:
                TaskRun();
                break;
            case InstanceCreatingType.TaskFactoryStartNew:
                TaskFactoryStartNew();
                break;
            default:
                break;
        }
        
        Console.ReadLine();
    }

    private void NewTask()
    {
        Task task = new(() =>
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine($"{i}");
        });
        task.Start();
    }

    private void TaskRun()
    {
        Task task = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine($"{i}");
        });
    }

    private void TaskFactoryStartNew()
    {
        Task task = Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine($"{i}");
        });
    }
}

public enum InstanceCreatingType
{
    NewTask = 1,
    TaskRun = 2,
    TaskFactoryStartNew = 3
}