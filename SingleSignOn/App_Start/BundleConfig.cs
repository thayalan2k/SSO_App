using System.Web.Optimization;

namespace SingleSignOn
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/signin.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery-3.0.0.min.js",
                "~/Scripts/modernizr-2.6.2.js"
                ));
        }
    }
}