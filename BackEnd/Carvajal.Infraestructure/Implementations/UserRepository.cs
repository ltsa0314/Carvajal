using Carvajal.Domain.Interfaces;
using Carvajal.Domain.Models;
using Carvajal.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Carvajal.Infraestructure.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CarvajalDbContext _context;

        public UserRepository(CarvajalDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var entity = _context.Users.Find(id);
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public bool Exists(string identification)
        {
            return _context.Users.Any(x => x.Identification == identification);
        }

        public IEnumerable<User> GetAll()
        {
            var entities = _context.Users.AsNoTracking().ToList();
            return entities;
        }

        public User GetById(int id)
        {
            var entity = _context.Users.Find(id);
            return entity;
        }

        public User Insert(User model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void Update(User model)
        {
            _context.Users.Update(model);
            _context.SaveChanges();
        }

        public bool ValidateUserPassword(string identification, string password)
        {
            return _context.Users.Any(x => x.Identification == identification && x.Password == password);
        }
    }
}
