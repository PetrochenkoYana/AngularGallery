namespace DAL.Interfacies.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string AccountImage { get; set; }

        public string PersonalInformation { get; set; }

        public int RoleId { get; set; }

       
    }
}