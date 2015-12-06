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

        public GreetingResult GetGreeting(string name)
        {
            return SayHello(name);
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
                HasSynchronizationContext = SynchronizationContext.Current != null,
                InitialCurrentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId,
                Greeting = "Hello, " + name
            };

            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                result.FinalCurrentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                return result;
            });
        }

        private GreetingResult SayHello(string name)
        {
            var result = new GreetingResult
            {
                HasSynchronizationContext = SynchronizationContext.Current != null,
                InitialCurrentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId,
                Greeting = "Hello, " + name
            };

            Thread.Sleep(1000);
            result.FinalCurrentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            return result;
        }
    }
}
