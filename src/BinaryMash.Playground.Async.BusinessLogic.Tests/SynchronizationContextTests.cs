using Nito.AsyncEx;
using Shouldly;
using Xunit;

namespace BinaryMash.Playground.Async.BusinessLogic.Tests
{
    public class SynchronizationContextTests
    {
        private readonly HelloWorldService _service;

        public SynchronizationContextTests()
        {
            _service = new HelloWorldService();
        }

        [Fact(Skip="Deadlock")]
        public void ShouldDeadlockWhenBlockedWithResultOnCapturedContext()
        {
            AsyncContext.Run(() =>
            {
                var result = _service.GetGreetingBlockedWithResultOnCapturedContext("world");
                result.Greeting.ShouldBe("Hello, world");
            });
        }

        [Fact(Skip="Deadlock")]
        public void ShouldDeadlockWhenBlockedWithAwaiterResultOnCapturedContext()
        {
            AsyncContext.Run(() =>
            {
                var result = _service.GetGreetingBlockedWithAwaiterResultOnCapturedContext("world");
                result.Greeting.ShouldBe("Hello, world");
            });
        }

        [Fact(Skip = "Deadlock")]
        public void ShouldReturnCorrectGreetingWhenBlockedWithAwaiterResultOnOtherContext()
        {
            AsyncContext.Run(() =>
            {
                var result = _service.GetGreetingBlockedWithAwaiterResultOnOtherContext("world");
                result.Greeting.ShouldBe("Hello, world");
            });
        }
    }
}
