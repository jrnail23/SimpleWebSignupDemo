namespace AwesomeThing.Admin
{
	using System.Collections.Generic;
    using Simple.Data;
    using Simple.Web;
    using Simple.Web.Behaviors;
    using Simple.Web.Http;

    [UriTemplate("/admin", false)]
    public class Admin : AdminBase, IGet, IOutput<List<Signup>>, ICacheability
    {
        public Status Get()
        {
            var db = Database.OpenNamedConnection("AwesomeThing");
            Output = db.Signups.All().ToList<Signup>();

            return 200;
        }

        public List<Signup> Output { get; set; }

        public CacheOptions CacheOptions
        {
            get { return CacheOptions.DisableCaching; }
        }
    }
}