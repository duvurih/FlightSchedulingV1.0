using System.Web.Optimization;

namespace FlightSchedulingProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/vendorscripts").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/jquery-2.1.1.js",
                      "~/Scripts/jquery.validate.js",
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-animate.js",
                      "~/Scripts/angular-route.js",
                      "~/Scripts/angular-sanitize.js",
                      "~/Scripts/angular-mocks.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/resoibd.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                      "~/Scripts/spin.js",
                      "~/Scripts/require.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/ie10mobile.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/toastr.css",
                      "~/Content/customtheme.css",
                      "~/Content/styles.css"));

            bundles.Add(new ScriptBundle("~/bundles/appscripts").Include(
                      "~/app/app.js",
                      "~/app/config.js",
                      "~/app/config.exceptionHandler.js",
                      "~/app/config.route.js",
                      "~/app/common/common.js",
                      "~/app/common/logger.js",
                      "~/app/common/spinner.js",
                      "~/app/common/bootstrap/bootstrap.dialog.js",
                      "~/app/admin/admin.js",
                      "~/app/dashboard/dashboard.js",
                      "~/app/layout/shell.js",
                      "~/app/layout/sidebar.js",
                      "~/app/services/dataservices.js",
                      "~/app/services/directives.js",
                      "~/app/services/modalpopup.factory.js",
                      "~/app/flight/flight.js",
                      "~/app/gate/gate.js"));

            BundleTable.EnableOptimizations = true;

        }
    }
}
