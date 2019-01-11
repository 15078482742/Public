using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EFCore
{
    public class ApiResourceEntity
    {
        [Key]
        public string ApiResourceId { get; set; }

    }
}
