using System;
namespace PandaTime.UserCatalog.Views
{
    public class BaseObject
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
