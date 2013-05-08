using System.Web;
using System.Web.Optimization;

namespace MiniFB
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
             //           "~/Scripts/jquery.unobtrusive*",
               //         "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            //var lessBundle = new Bundle("~/less").IncludeDirectory("~/Content/less", "*.less");
            //lessBundle.Transforms.Add(new LessTransform());
            //lessBundle.Transforms.Add(new CssMinify());
            //bundles.Add(lessBundle);

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js")
                        .Include("~/Scripts/bootstrap-affix.js")
                        .Include("~/Scripts/bootstrap-alert.js")
                        .Include("~/Scripts/bootstrap-button.js")
                        .Include("~/Scripts/bootstrap-carousel.js")
                        .Include("~/Scripts/bootstrap-collapse.js")
                        .Include("~/Scripts/bootstrap-dropdown.js")
                        .Include("~/Scripts/bootstrap-modal.js")
                        .Include("~/Scripts/bootstrap-tooltip.js")
                        .Include("~/Scripts/bootstrap-popover.js")
                        .Include("~/Scripts/bootstrap-scrollspy.js")
                        .Include("~/Scripts/bootstrap-tab.js")
                        .Include("~/Scripts/bootstrap-transition.js")
                        .Include("~/Scripts/bootstrap-typeahead.js"));
            bundles.Add(new StyleBundle("~/Content/bootstrap/css")
                        .Include("~/Content/bootstrap.css")
                        .Include("~/Content/bootstrap-responsive.css"));
        }
    }
}