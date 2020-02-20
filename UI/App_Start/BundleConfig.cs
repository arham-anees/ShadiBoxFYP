using System.Web;
using System.Web.Optimization;

namespace UI {
	public class BundleConfig {
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles) {
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
									"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
									"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
									"~/Scripts/modernizr-*"));

			//bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
			//					"~/Scripts/bootstrap.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
								"~/Content/bootstrap.css",
								"~/Content/css/bootstrap.min.css",
								"~/Content/css/datepicker.css",
								"~/Content/css/flaticon.css",
								"~/Content/css/font-awesome.min.css",
								"~/Content/css/fontello.css",
								"~/Content/css/index-style.css",
								"~/Content/css/magnific-popup.css",
								"~/Content/css/menumaker.css",
								"~/Content/css/owl.carousel.css",
								"~/Content/css/owl.transitions.css",
								"~/Content/css/select2-bootstrap.css",
								"~/Content/css/style.css",
								"~/Content/css/new/final_style_sheet.css",
								"~/Content/css/new/jquerysctipttop.css",
								"~/Content/css/new/modal-video.min.css",
								"~/Content/css/new/new-style.css",
								"~/Content/css/new/owl.carousel.css",
								"~/Content/css/new/owl.theme.css",
								"~/Content/css/new/popup.css",
								"~/Content/css/new/select2-bootstrap.css",
								"~/Content/css/new/style.css"));
		}
	}
}
