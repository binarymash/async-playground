using BinaryMash.Playground.Async.BusinessLogic;
using Nito.AsyncEx;

namespace BinaryMash.Playground.Async.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var formatter = new ResultFormatter();
            bool askForInput = true;
            var service = new HelloWorldService();

            while (askForInput)
            {
                System.Console.WriteLine("Select...");
                System.Console.WriteLine("1: No SynchronizationContext when blocked with result on captured context...");
                System.Console.WriteLine("2: No SynchronizationContext when blocked with awaiter result on captured context...");
                System.Console.WriteLine("3: No SynchronizationContext when blocked with awaiter result on other context...");
                System.Console.WriteLine("4: SynchronizationContext when awaiting in AsyncContext...");
                System.Console.WriteLine("5: SynchronizationContext when blocked with result on captured context... (WILL DEADLOCK)");
                System.Console.WriteLine("6: SynchronizationContext when blocked with awaiter result on captured context... (WILL DEADLOCK)");
                System.Console.WriteLine("7: SynchronizationContext when blocked with awaiter result on other context... (WILL DEADLOCK)");


                var input = System.Console.ReadLine();

                switch (input)
                {
                    case "1":
                        System.Console.WriteLine("1: " + formatter.Format(service.GetGreetingBlockedWithResultOnCapturedContext("world")));
                        break;
                    case "2":
                        System.Console.WriteLine("2: " + formatter.Format(service.GetGreetingBlockedWithAwaiterResultOnCapturedContext("world")));
                        break;
                    case "3":
                        System.Console.WriteLine("3: " + formatter.Format(service.GetGreetingBlockedWithAwaiterResultOnOtherContext("world")));
                        break;
                    case "4":
                        AsyncContext.Run(async () =>
                        {
                            System.Console.WriteLine("4: " + formatter.Format(await service.GetGreetingAsync("world")));
                        });
                        break;
                    case "5":
                        AsyncContext.Run(() =>
                        {
                            System.Console.WriteLine("5: " + formatter.Format(service.GetGreetingBlockedWithResultOnCapturedContext("world")));
                        });
                        break;
                    case "6":
                        AsyncContext.Run(() =>
                        {
                            System.Console.WriteLine("6: " + formatter.Format(service.GetGreetingBlockedWithAwaiterResultOnCapturedContext("world")));
                        });
                        break;
                    case "7":
                        AsyncContext.Run(() =>
                        {
                            System.Console.WriteLine("7: " + formatter.Format(service.GetGreetingBlockedWithAwaiterResultOnOtherContext("world")));
                        });
                        break;
                    default:
                        askForInput = false;
                        break;
                }
            }




            System.Console.WriteLine("Finished!");
            System.Console.ReadLine();
        }
    }
}
