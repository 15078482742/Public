using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.EFCore
{
    public class SecretEntity
    {
        [Key]
        public string SecretId { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public DateTime? Expiration { get; set; }

        public string Type { get; set; }

        public ApiResourceEntity ApiResourceId { get; set; }
        public ApiResourceEntity ApiResource { get; set; }
    }
}