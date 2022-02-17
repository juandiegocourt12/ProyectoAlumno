using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Net52.Rest.API.Construction.Contexts;
using Net52.Rest.API.Construction.Entities;
using Net52.Rest.API.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProjectAlumno
{
    public class Tests
    {
        private DbContextOptions<ProyalumnoContext> _DBContextOptions = new DbContextOptionsBuilder<ProyalumnoContext>()
       .UseInMemoryDatabase(databaseName: "TestAlumno")
       .Options;

        private ProyalumnoContext _ProyalumnoContext;
        private AlumnoController _alumnoController;
        private readonly ILogger<AlumnoController> _logger;
        [SetUp]
        public void Setup()
        {
            SeedDb();
            _ProyalumnoContext = new ProyalumnoContext(_DBContextOptions);
            _alumnoController = new AlumnoController(_ProyalumnoContext, _logger);
        }

        [Test]
        public async Task ToListAsync()
        {
            var result = await _ProyalumnoContext.People.ToListAsync();
            Assert.LessOrEqual(result.Count, 5);
        }
        [Test]
        public async Task GetAsync()
        {
            var result = await _ProyalumnoContext.People.FindAsync(101);

            //result.FirstName.
            //Persona..Should().Be("Teclado");
            Assert.AreEqual(result.PersonId, 100);
        }


        private void SeedDb()
        {
            using var context = new ProyalumnoContext(_DBContextOptions);
            List<Person> people = new List<Person>

            {
                new Person{ PersonId = 100, FirstName = "JORGE", LastName = "Ramirez",HireDate =null, EnrollmentDate=System.DateTime.Today, Discriminator = "student" },
                new Person{ PersonId = 101, FirstName = "Jhon", LastName = "Stuart",HireDate =null, EnrollmentDate=DateTime.Today, Discriminator = "student" },
                new Person{ PersonId = 102, FirstName = "Levi", LastName = "Ackerman",HireDate =null, EnrollmentDate=DateTime.Today, Discriminator = "student" },
                new Person{ PersonId = 103, FirstName = "Bobby", LastName = "Lashley",HireDate =null, EnrollmentDate=DateTime.Today, Discriminator = "student" },
                new Person{ PersonId = 104, FirstName = "Sam", LastName = "Warez",HireDate =null, EnrollmentDate=DateTime.Today, Discriminator = "student" },
                //new Person{ PersonId = 1, FirstName = "JORGE", LastName = "Ramirez",HireDate =null, EnrollmentDate=DateTime.Today, Discriminator = "student" },
            };

            context.People.AddRange(people);
            context.SaveChanges();
        }
    }
}