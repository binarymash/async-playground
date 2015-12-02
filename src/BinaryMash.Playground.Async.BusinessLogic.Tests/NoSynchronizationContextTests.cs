using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace BinaryMash.Playground.Async.BusinessLogic.Tests
{
    public class NoSynchronizationContextTests
    {
        private readonly HelloWorldService _service;

        public NoSynchronizationContextTests()
        {
            _service = new HelloWorldService();
        }

        [Fact]
        public async Task ShouldReturnGreetingWhenNotBlocked()
        {
            var result = await _service.GetGreetingAsync("world");
            result.Greeting.ShouldBe("Hello, world");
            result.HasSynchronisationContext.ShouldBe(true);
            result.FinalCurrentThreadId.ShouldNotBe(result.InitialCurrentThreadId);
        }

        [Fact]
        public void ShouldReturnGreetingWhenBlockedWithResultOnCapturedContext()
        {
            var result = _service.GetGreetingBlockedWithResultOnCapturedContext("world");
            result.Greeting.ShouldBe("Hello, world");
            result.HasSynchronisationContext.ShouldBe(true);
            result.FinalCurrentThreadId.ShouldNotBe(result.InitialCurrentThreadId);
        }

        [Fact]
        public void ShouldReturnGreetingWhenBlockedWithAwaiterResultOnCapturedContext()
        {
            var result = _service.GetGreetingBlockedWithAwaiterResultOnCapturedContext("world");
            result.Greeting.ShouldBe("Hello, world");
            result.HasSynchronisationContext.ShouldBe(true);
            result.FinalCurrentThreadId.ShouldNotBe(result.InitialCurrentThreadId);
        }

        [Fact]
        public void ShouldReturnGreetingWhenBlockedWithAwaiterResultOnOtherContext()
        {
            var result = _service.GetGreetingBlockedWithAwaiterResultOnOtherContext("world");
            result.Greeting.ShouldBe("Hello, world");
            result.HasSynchronisationContext.ShouldBe(true);
            result.FinalCurrentThreadId.ShouldNotBe(result.InitialCurrentThreadId);
        }
    }
}
