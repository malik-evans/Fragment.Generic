using System.Collections.Generic;

namespace Fragment.Generic.App.Helpers
{

    public class Link
    {
        public string Href { get; set; }
        public string Target { get; set; }
        public string Name { get; set; }
    }

    public class AppStaticRoutes
    {
        public List<Link> Links { get; set; }
    }
}
