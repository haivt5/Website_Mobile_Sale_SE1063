using System.Web;
using System.Web.Mvc;

namespace Website_Mobile_Sale_SE1063
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
