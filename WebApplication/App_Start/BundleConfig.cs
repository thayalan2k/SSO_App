using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/starter-template.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery-3.0.0.min.js",
                "~/Scripts/modernizr-2.6.2.js"
                ));
        }
    }
}