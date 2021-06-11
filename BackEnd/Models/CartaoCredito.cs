using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class CartaoCredito
    {
        public int Id { get; set; }

        [Required]
        public string Titular { get; set; }

        [Required]
        public string NumeroCartao { get; set; }

        [Required]
        public string DataExpiracao { get; set; }

        [Required]
        public string CVV { get; set; }
    }
}
