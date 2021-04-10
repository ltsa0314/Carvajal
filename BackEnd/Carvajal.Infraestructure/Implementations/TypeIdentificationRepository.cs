using Carvajal.Domain.Interfaces;
using Carvajal.Domain.Models;
using Carvajal.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Carvajal.Infraestructure.Implementations
{
    public class TypeIdentificationRepository : ITypeIdentificationRepository
    {
        private readonly CarvajalDbContext _context;

        public TypeIdentificationRepository(CarvajalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TypeIdentification> GetAll()
        {
            var entities = _context.TypeIdentifications.AsNoTracking().ToList();
            return entities;
        }
    }
}
