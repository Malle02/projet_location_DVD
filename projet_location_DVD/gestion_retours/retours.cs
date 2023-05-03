using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace projet_location_DVD.gestion_retours
{
    //internal class retour
    // Classe Retour : représente le retour d'un DVD loué
    public class retours
    {
        public int RetourId { get; set; }
        public int LaLocation { get; set; }
        public DateTime DateReturned { get; set; }

        public bool EstSelectionne { get; set; } // Ajout de la propriété IsSelected



    }
}
