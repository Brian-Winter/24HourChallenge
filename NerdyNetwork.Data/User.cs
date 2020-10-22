using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdyNetwork.Data
{
    public class User
    {
        [key]
        public int UserId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Woah that's a lot of characters for this field.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Yo, that's too many characters for this field.")]
        public string Email { get; set; }

    }
}
