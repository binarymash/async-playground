﻿namespace BinaryMash.Playground.Async.BusinessLogic
{
    public class GreetingResult
    {
        public bool HasSynchronizationContext { get; set; }

        public int InitialCurrentThreadId { get; set; }

        public int FinalCurrentThreadId { get; set; }

        public string Greeting { get; set; }
    }
}
