using System.Web;
using System.Web.Optimization;

namespace TN.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/bundles/js/jquery-1.7.2.min.js",
                      "~/bundles/js/twitter-text.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-migrate-1.2.1.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.10.4.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/searchAjax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/sliders").Include(
                        "~/Scripts/plugins/back-to-top.js",
                        "~/Scripts/plugins/flexslider/jquery.flexslider-min.js",
                        "~/Scripts/plugins/bxslider/jquery.bxslider.js",
                        "~/Scripts/plugins/layer_slider/jQuery/jquery-easing-1.3.js",
                        "~/Scripts/plugins/layer_slider/jQuery/jquery-transit-modified.js",
                        "~/Scripts/plugins/layer_slider/js/layerslider.transitions.js",
                        "~/Scripts/plugins/layer_slider/js/layerslider.transitions.js",
                        "~/Scripts/plugins/layer_slider/js/layerslider.kreaturamedia.jquery.js"

                        ));

            bundles.Add(new StyleBundle("~/Content/genericCSS").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/style.css",
                      "~/Content/css/line-icons.css",
                      "~/Content/css/font-awesome/css/font-awesome.min.css"

                      ));


        }
    }
}

