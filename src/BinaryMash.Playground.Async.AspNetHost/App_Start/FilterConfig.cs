using System.Web.Mvc;

namespace BinaryMash.Playground.Async.AspNetHost
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
