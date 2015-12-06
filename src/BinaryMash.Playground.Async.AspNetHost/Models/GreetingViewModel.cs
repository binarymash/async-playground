namespace BinaryMash.Playground.Async.AspNetHost.Models
{
    public class GreetingViewModel
    {
        public string Greeting { get; set; }

        public bool HasSynchronizationContext { get; set; }

        public int InitialCurrentThreadId { get; set; }

        public int FinalCurrentThreadId { get; set; }

    }
}
