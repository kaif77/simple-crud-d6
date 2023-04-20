using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace simple_crud.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProgrammeController : ControllerBase
    {
        private static readonly Programme programme = new();

        public ProgrammeService _programmeService;

        public ProgrammeController(ProgrammeService programmeService)
        {
            _programmeService = programmeService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllProgrammes()
        {
            var program = _programmeService.GetAllProgrammes();
            return Ok(program);
        }

        [HttpPost("create-program")]
        public ResponseEntity CreateProgramme([FromBody] Programme programme)
        {
            return _programmeService.AddNewProgramme(programme);
        }

        [HttpPut("update-programme")]
        public ResponseEntity UpdateProgramme(int id, [FromBody] Programme programme)
        {
            return _programmeService.UpdateProgramme(id, programme);
        }

        [HttpDelete("delete-programme")]
        public ResponseEntity DeleteProgramme(int id)
        {
            return _programmeService.DeleteProgramById(id);
        }
    }
}