using OleynikProject.Models;
using System;
using System.Data.Entity;

namespace VytasProject.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
            var services1 = new Services
            {
                Title = "Массаж",
                Description = "Приемы механического и рефлекторного воздействия на ткани и органы в виде растирания, давления, вибрации, проводимых непосредственно на " +
                "поверхности тела человека как руками, так и специальными аппаратами через воздушную, водную или иную среду с целью достижения лечебного или иного эффекта.",
                Cost = 10
            };
            var services2 = new Services
            {
                Title = "Стрижка",
                Description = "Придаваемая волосам стрижка, завивкой, укладкой и филировкой, подбором цветовой гаммы. " +
                "Может быть из естественных и искусственных волос с шиньонами и прядями разных цветов.",
                Cost = 10
            };

            db.Services.Add(services1);
            db.Services.Add(services2);

            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            dt = dt.AddMinutes(-dt.Minute);

            var service1 = new Service { Name = "Egor", Email = "Egor@gmail.com", StartTime = dt, Services = services1 };
            dt = dt.AddHours(1);
            var service2 = new Service { Name = "Nastja", Email = "Nastja@gmail.com", StartTime = dt, Services = services2 };
            dt = dt.AddHours(1);
            var service3 = new Service { Name = "Artjom", Email = "Artjom@gmail.com", StartTime = dt, Services = services2 };

            db.Service.Add(service1);
            db.Service.Add(service2);
            db.Service.Add(service3);

            base.Seed(db);
        }
    }
}
