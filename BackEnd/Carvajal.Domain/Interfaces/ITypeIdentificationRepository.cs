using Carvajal.Domain.Models;
using System.Collections.Generic;

namespace Carvajal.Domain.Interfaces
{
    public interface ITypeIdentificationRepository
    {
        IEnumerable<TypeIdentification> GetAll();
    }
}
