namespace GeoObservables.Api.ViewModels
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int IdRole { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
