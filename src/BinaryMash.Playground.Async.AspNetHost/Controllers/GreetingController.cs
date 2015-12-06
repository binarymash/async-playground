using System.Threading.Tasks;
using System.Web.Mvc;
using BinaryMash.Playground.Async.AspNetHost.Models;
using BinaryMash.Playground.Async.BusinessLogic;

namespace BinaryMash.Playground.Async.AspNetHost.Controllers
{
    public class GreetingController : Controller
    {
        readonly HelloWorldService _service = new HelloWorldService();

        public ActionResult Index()
        {
            return View("Index", null);
        }

        public async Task<ActionResult> ACGreetingAsync()
        {
            var result = await _service.GetGreetingAsync("World");
            return View("Index", MapToViewModel(result));
        }

        public ActionResult SCGreetingBlockedWithAwaiterResultOnCapturedContext()
        {
            var result = _service.GetGreetingBlockedWithAwaiterResultOnCapturedContext("World");
            return View("Index", MapToViewModel(result));
        }

        public async Task<ActionResult> ACGreetingBlockedWithAwaiterResultOnCapturedContext()
        {
            return SCGreetingBlockedWithAwaiterResultOnCapturedContext();
        }

        public ActionResult SCGreetingBlockedWithAwaiterResultOnOtherContext()
        {
            var result = _service.GetGreetingBlockedWithAwaiterResultOnOtherContext("World");
            return View("Index", MapToViewModel(result));
        }

        public async Task<ActionResult> ACGreetingBlockedWithAwaiterResultOnOtherContext()
        {
            return SCGreetingBlockedWithAwaiterResultOnOtherContext();
        }

        public ActionResult SCGreetingBlockedWithResultOnCapturedContext()
        {
            var result = _service.GetGreetingBlockedWithResultOnCapturedContext("World");
            return View("Index", MapToViewModel(result));
        }

        public async Task<ActionResult> ACGreetingBlockedWithResultOnCapturedContext()
        {
            return SCGreetingBlockedWithResultOnCapturedContext();
        }

        public ActionResult SCGreeting()
        {
            var result = _service.GetGreeting("World");
            return View("Index", MapToViewModel(result));
        }

        public async Task<ActionResult> ACGreeting()
        {
            return SCGreeting();
        }


        private GreetingViewModel MapToViewModel(GreetingResult greeting)
        {
            return new GreetingViewModel
            {
                Greeting = greeting.Greeting,
                HasSynchronizationContext = greeting.HasSynchronizationContext,
                InitialCurrentThreadId = greeting.InitialCurrentThreadId,
                FinalCurrentThreadId = greeting.FinalCurrentThreadId
            };
        }
    }
}