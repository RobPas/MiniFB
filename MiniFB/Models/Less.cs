using System.Web.Optimization;

// http://www.asp.net/mvc/tutorials/mvc-4/bundling-and-minification

public class LessTransform : IBundleTransform
{
    public void Process(BundleContext context, BundleResponse response)
    {
        response.Content = dotless.Core.Less.Parse(response.Content);
        response.ContentType = "text/css";
    }
}