public class AutoResetEventClass
{
    private static AutoResetEvent AutoEvent = new AutoResetEvent(false);

    //private static EventWaitHandle AutoEvent = new EventWaitHandle(false, EventResetMode.AutoReset);

    public static void Main(String[] args)
    {

        for (int i = 0; i <= 2; i++)
        {
            Thread t = new Thread(ThreadProcedure);
            t.Name = "Thread_" + i;
            t.Start();
        }

        Thread.Sleep(500);
        Console.WriteLine("Press Enter to signal the waiting threads");
        Console.ReadLine();

        AutoEvent.Set();
        Console.ReadLine();

        AutoEvent.Set();
        Console.ReadLine();

        AutoEvent.Set();
        Console.ReadLine();


        Thread.Sleep(500);
    }


    private static void ThreadProcedure()
    {
        string name = Thread.CurrentThread.Name;

        Console.WriteLine(name + " starts and calls WaitOne()");

        AutoEvent.WaitOne();

        Console.WriteLine(name + " Realeased.");
        Thread.Sleep(500);
    }


}