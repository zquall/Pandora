using System.Web;

namespace PithosApi.Utils
{
    public static class GlobalVariables
    {
        // readonly variable
        public static string Foo { get { return "foo"; } }

        // read-write variable
        public static string SapSessionId
        {
            get { return HttpContext.Current.Application["SapSessionId"] as string; }
            set { HttpContext.Current.Application["SapSessionId"] = value; }
        }
    }
}