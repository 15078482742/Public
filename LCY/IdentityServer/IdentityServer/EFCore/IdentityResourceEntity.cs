using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EFCore
{
    public class IdentityResourceEntity
    {
        [Key]
        public string IdentityResourceId { get; set; }
        public bool Required { get; set; }

        public bool Emphasize { get; set; }

        public bool ShowInDiscoveryDocument { get; set; }
    }
}
