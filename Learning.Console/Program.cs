using Learning.AsynchronousAndMultithreadingProgramming._12_ThreadLocalStorage;
using TaskFactory = Learning.AsynchronousAndMultithreadingProgramming._15_TaskFactory_TaskScheduler_TaskCompletionSource.TaskFactory;

TaskFactory example = new();
example.Run(TaskFactory.MethodToRun.ContinueWhenAny);
Console.ReadKey();