using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace M2W5Assessment
{
    public class Performer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Members { get; set; }
        public List<Concert> AttendingConcerts { get; set; }
    }
}
