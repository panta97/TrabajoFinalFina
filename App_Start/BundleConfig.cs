using System.Web;
using System.Web.Optimization;

namespace Cashflow
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

//            own configurations

            bundles.Add(new ScriptBundle("~/bundles/mentor/scripts").Include(
                "~/Mentor/js/jquery/min.js",
                "~/Mentor/js/jquery.easing.min.js",
                "~/Mentor/js/bootstrap.min.js",
                "~/Mentor/js/custom.js",
                "~/Mentor/contactform/contactform.js",

                "~/Scripts/bootbox.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js",
                "~/Scripts/DataTables/Spanish.js"            

                ));

            bundles.Add(new ScriptBundle("~/bundles/datetime/scripts").Include(
//                "/Scripts/jquery.min.js",
                "~/Scripts/moment.min.js",
//                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap-datetimepicker.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                "~/Scripts/Chart.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

//            own configurations

            bundles.Add(new StyleBundle("~/bundles/mentor/css").Include(
                "~/Mentor/css/font-awesome.min.css",
                "~/Mentor/css/bootstrap.min.css",
                "~/Mentor/css/imagehover.min.css",
                "~/Mentor/css/style.css",

                "~/Content/bootstrap-datetimepicker.css",
                "~/Content/DataTables/css/dataTables.bootstrap.css",

                "~/Content/custom-cover.css"
                ));

//            bundles.Add(new StyleBundle("~/bundles/datetime/css").Include(
//                "~/Content/bootstrap-datetimepicker.css"
//                ));
        }
    }
}
