using System;
using System.Text;

namespace BinaryMash.Playground.Async.BusinessLogic
{
    public class ResultFormatter
    {
        public string Format(GreetingResult result)
        {
            var builder = new StringBuilder();

            builder.AppendFormat("Has SynchronisationContext: {0}{1}", result.HasSynchronisationContext, Environment.NewLine);
            builder.AppendFormat("Initial CurrentThread Id: {0}{1}", result.InitialCurrentThreadId, Environment.NewLine);
            builder.AppendFormat("Final CurrentThread Id: {0}{1}", result.FinalCurrentThreadId, Environment.NewLine);
            builder.AppendFormat("Greeting: {0}{1}", result.Greeting, Environment.NewLine);

            return builder.ToString();
        }
    }
}
