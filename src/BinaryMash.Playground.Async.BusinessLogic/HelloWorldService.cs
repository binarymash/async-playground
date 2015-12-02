using System.Threading;
using System.Threading.Tasks;

namespace BinaryMash.Playground.Async.BusinessLogic
{
    public class HelloWorldService
    {
        public async Task<GreetingResult> GetGreetingAsync(string name)
        {
            return await SayHelloAsync(name);
        }

        public GreetingResult GetGreetingBlockedWithResultOnCapturedContext(string name)
        {
            return SayHelloAsync(name).Result;
        }

        public GreetingResult GetGreetingBlockedWithAwaiterResultOnCapturedContext(string name)
        {
            return SayHelloAsync(name).GetAwaiter().GetResult();
        }

        public GreetingResult GetGreetingBlockedWithAwaiterResultOnOtherContext(string name)
        {
            return SayHelloAsync(name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async Task<GreetingResult> SayHelloAsync(string name)
        {
            var result = new GreetingResult()
            {
                HasSynchronisationContext = SynchronizationContext.Current != null,
                InitialCurrentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId,
                Greeting = "Hello, " + name
            };

//            await Task.Delay(1000);


            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                result.FinalCurrentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                return result;
            });

        }
    }
}
