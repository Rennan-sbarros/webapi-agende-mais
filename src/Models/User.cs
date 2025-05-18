
namespace webapi_agende_mais.src.Models
{
    public enum TipoUsuario
    {
        ADMIN,
        PROFESSIONAL,
        CUSTOMER
    }

    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public TipoUsuario TypeUser { get; set; }

        public DateTime CreatedIn { get; set; }
    }

}
