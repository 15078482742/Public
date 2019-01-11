using System.ComponentModel.DataAnnotations;

namespace IdentityServer.EFCore
{
    public class ClientEntity
    {
        [Key]
        public string ClientId { get; set; }

        public string ClientSecrets { get; set; }
        public string AllowedGrantTypes { get; set; }
        public string AllowedScopes { get; set; }
    }
}