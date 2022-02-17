using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Rest.Infrastructure.CrossCutting.Dtos
{

    public class PersonDtoForUpdate
    {
        public PersonDtoForUpdate()
        {
            
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public object PersonId { get; set; }
    }
}
