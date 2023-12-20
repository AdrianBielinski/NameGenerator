using Dapper;
using NameGenerator.Data.Entities;
using NameGenerator.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameGenerator.Core.Interfaces;

namespace NameGenerator.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseService _databaseService;

        public PersonRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            using var connection = _databaseService.CreateConnection();
            return await connection.QueryAsync<Person>("SELECT * FROM Persons");
        }
    }
}
