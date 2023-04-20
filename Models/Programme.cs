using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_crud.Models
{
    public class Programme
    {
        public int Id { get; set; }
        public string ProgrammeName { get; set; } = "Program";
        public string ProgrammeDescription { get; set; } = "Programme description";
        public string ProgrammeCoordinator { get; set; } = "ProgramCoordinator";
    }
}