using System.Web;
using System.Web.Optimization;

namespace PandoraShell
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/dx.common.css",
                     // "~/Content/dx.dark.compact.css",
                      "~/Content/dx.light.compact.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
               "~/Scripts/angular.js",
               "~/Scripts/angular-sanitize.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/devextreme").Include(
                        "~/Scripts/globalize.js",
                        "~/Scripts/dx.all.js"));
            

        }
    }
}
