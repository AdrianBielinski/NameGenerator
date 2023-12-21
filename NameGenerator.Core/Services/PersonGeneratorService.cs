using NameGenerator.Core.Data;
using NameGenerator.Core.Interfaces;
using NameGenerator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGenerator.Core.Services
{
    public class PersonGeneratorService : IPersonGeneratorService
    {
        private readonly IPersonRepository _personRepository;

        public PersonGeneratorService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task GenerateAndSavePersons(int count, string ipAddress)
        {
            // add null protection
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                var firstName = PredefinedNames.FirstNames[random.Next(PredefinedNames.FirstNames.Count)];
                var lastName = PredefinedNames.LastNames[random.Next(PredefinedNames.LastNames.Count)];

                var person = new Person { FirstName = firstName, LastName = lastName, Address_IP_Generated = ipAddress };
                await _personRepository.AddPersonAsync(person);
            }
        }
    }
}
