using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Library
    {
        //the attributes that need to be filled
        public int Id { get; set; }
        public string Name { get; set; }
        public int LibraryPopulation { get; set; }
        public string LibraryAddress { get; set; }
    }
}
