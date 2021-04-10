namespace Carvajal.Api.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TypeIdentificationId { get; set; }
        public string Identification { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
