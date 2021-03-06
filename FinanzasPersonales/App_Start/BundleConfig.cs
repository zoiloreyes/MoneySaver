﻿using System.Web;
using System.Web.Optimization;

namespace FinanzasPersonales
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/UtilidadesJS.js", 
                        "~/Scripts/DashboardScript.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome-4.7.0/css/font-awesome.css",
                      "~/Content/materialize.css",
                      "~/Content/animate.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/plugincss").Include(
                      "~/Content/css/select2.min.css",
                      "~/Content/DataTable/datatables.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/pluginjs").Include(
               "~/Scripts/select2.min.js",
               "~/Scripts/datatables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                "~/Scripts/materialize.js"));
        }
    }
}
