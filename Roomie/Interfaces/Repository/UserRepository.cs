using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Roomie.Data;
using Roomie.Dtos.ForResponse;
using Roomie.Entity;

namespace Roomie.Interfaces.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;   

        }

        public async Task<AppUserDto> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .Include(p => p.ProfilePicture)
/*                .Include(p => p.Posts)*/
                .ProjectTo<AppUserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<AppUserDto> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<AppUserDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<AppUserDto>> GetUsersAsync()
        {
            return await _context.Users
                .ProjectTo<AppUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
