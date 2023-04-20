using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_crud.Entity
{
    public class ResponseEntity
    {
        public string Message { get; set; } = "Response";
        public int StatusCode { get; set; }
    }
}