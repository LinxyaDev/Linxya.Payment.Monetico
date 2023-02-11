using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linxya.Payment.Monetico.Models.Configuration
{
    public class MoneticoConfiguration
    {
        public bool UseSandBox { get; set; } = true;
        public string? SocietyCode { get; set; }
        public string? Tpe { get; set; }
        public string? MacKey { get; set; }
        public string? Version { get; set; }

        public string PayementUrl => $"https://p.monetico-services.com/{(UseSandBox ? "test/" : "")}paiement.cgi";
    }
}
