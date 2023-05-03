using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_location_DVD.gestion_retours.Ajout
{
    public class location
    {




        public int LocationId { get; set; }
        public int LeClient { get; set; }
        public int LeDVD { get; set; }
        public DateTime dateRented { get; set; }
        public DateTime dateReturned { get; set; }

    }
}
