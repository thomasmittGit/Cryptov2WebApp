using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cryptov2WebApp.Models
{
    public class Users
    {
        [Key]
        public Int32 id { get; set; }
        [Required(ErrorMessage = "Por favor digite o nome de usuário")]
        public String username { get; set; }
        [Required(ErrorMessage = "Por favor digite a senha")]
        public String senha { get; set; }
        public Int32 apiKey { get; set; }
    }
}
