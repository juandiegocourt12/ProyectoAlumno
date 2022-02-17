using System;

namespace Net5.Rest.Infrastructure.CrossCutting.Dtos
{
    public class PersonaDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Discriminator { get; set; }
    }
}
