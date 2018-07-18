using System;
namespace PandaTime.UserCatalog.Views
{
    public class Language : BaseObject
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Default { get; set; }
    }
}
