using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_crud.Services
{
    public class ProgrammeService
    {
        private readonly ProgrammeDbContext _dbContext;

        public ProgrammeService(ProgrammeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseEntity AddNewProgramme(Programme program)
        {
            var temProgram = new Programme()
            {
                ProgrammeName = program.ProgrammeName,
                ProgrammeCoordinator = program.ProgrammeCoordinator,
                ProgrammeDescription = program.ProgrammeDescription
            };

            _dbContext.Programmes.Add(temProgram);
            var res = _dbContext.SaveChanges();
            if (res > 0)
            {
                return new ResponseEntity
                {
                    Message = "Create Program successfully",
                    StatusCode = StatusCodes.Status201Created
                };
            }
            return new ResponseEntity
            {
                Message = "Could Not Create Program",
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        public List<Programme> GetAllProgrammes()
        {
            return _dbContext.Programmes.ToList();
        }

        public Programme GetProgrammeById(int id) => _dbContext.Programmes.FirstOrDefault(p => p.Id == id);

        public Programme GetProgramByName(string name) => _dbContext.Programmes.FirstOrDefault(p => p.ProgrammeName == name);

        public ResponseEntity UpdateProgramme(int programId, Programme programVM)
        {
            var program = _dbContext.Programmes.FirstOrDefault(p => p.Id == programId);

            if (program != null)
            {
                program.Id = programVM.Id;
                program.ProgrammeName = programVM.ProgrammeName;
                program.ProgrammeCoordinator = programVM.ProgrammeCoordinator;
                program.ProgrammeDescription = programVM.ProgrammeDescription;

                _dbContext.SaveChanges();
                return new ResponseEntity
                {
                    Message = "Program updated successfully",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new ResponseEntity
                {
                    Message = "Program Not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }

        public ResponseEntity DeleteProgramById(int id)
        {
            var program = _dbContext.Programmes.FirstOrDefault(p => p.Id == id);
            if (program != null)
            {
                _dbContext.Programmes.Remove(program);
                _dbContext.SaveChanges();
                return new ResponseEntity
                {
                    Message = "Program deleted successfully",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new ResponseEntity
                {
                    Message = "Program not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }
    }
}