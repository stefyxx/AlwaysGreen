using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    //SIRET: 123 568 941 00056 --> SIREN: 123 568 941 + NIC: 00056
    public class Siret
    {
        [Key]
        public int? Id { get; set; }

        public string Siren { get; set; }

        //string because you can have 0 at first
        public string NIC { get; set; }
    }
}
/*
* Siret signifie Système d'identification du répertoire des établissements. Il est composé de 14 chiffres : les 9 chiffres du Siren + 5 chiffres propres à chaque établissement (ces 5 chiffres sont appelés NIC, numéro interne de classement Insee)
*/