using Microsoft.EntityFrameworkCore;
using UserRegister.Data;
using UserRegister.Models;

namespace UserRegister.Services
{
    public class UserServices
    {
        private readonly ApplicationDbContext _context;

        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserById(Guid id) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User?> GetUserByEmail(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<List<User>> getUserAll() =>
            await _context.Users.ToListAsync();
        public async Task<User> CreateUser(UserCreateDTO user)
        {
            try
            {
                User usuario = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    Created = DateTime.UtcNow,//añadido por mi para auditoria
                    Modified = DateTime.UtcNow,//añadido por mi para auditoria
                    LastLogin = DateTime.UtcNow,//añadido por mi para auditoria
                    IsActive = true,//añadido por mi para no eliminar el usuario no esta en la tarea pero es buena practica
                    Token = Guid.NewGuid().ToString(),//añadido por mi para auditoria
                    Phones = user.Phones.Select(p => new Phone
                    {
                        Number = p.Number,
                        CityCode = p.CityCode,
                        CountryCode = p.CountryCode
                    }).ToList()
                };
                _context.Users.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el proceso de crear el usuario: Leea el detalle: "+ex);
            } 
        }
    }
}
