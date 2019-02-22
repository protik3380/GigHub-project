using GigHub_Fundamental.Models;
using System.Collections.Generic;

namespace GigHub_Fundamental.ViewModel
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTearm { get; set; }
    }
}