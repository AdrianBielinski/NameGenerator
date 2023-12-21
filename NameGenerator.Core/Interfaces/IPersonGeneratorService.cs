using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGenerator.Core.Interfaces
{
    public interface IPersonGeneratorService
    {
        Task GenerateAndSavePersons(int count);
    }

}
