using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_crud.DB
{
    public class ProgrammeDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var services = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = services.ServiceProvider.GetService<ProgrammeDbContext>();

                if (!context.Programmes.Any())
                {
                    context.Programmes.AddRange(new Programme()
                    {
                        ProgrammeName = "1st Program",
                        ProgrammeDescription = "1st Program Description",
                        ProgrammeCoordinator = "1st ProgramCoordinator",
                    },
                    new Programme()
                    {
                        ProgrammeName = "2nd Program",
                        ProgrammeDescription = "2nd Program Description",
                        ProgrammeCoordinator = "2nd ProgramCoordinator",
                    }
);

                    context.SaveChanges();
                }
            }
        }
    }
}