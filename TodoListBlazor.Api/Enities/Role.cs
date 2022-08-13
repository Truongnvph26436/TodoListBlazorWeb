using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListBlazor.Api.Enities
{
    public class Role : IdentityRole<Guid>
    {
        [MaxLength(250)]
        [Required]
        public string Desription { get; set; }
    }
}
