using CQRS.Data;
using CQRS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services
{
    public class UserRequestService: IUserRequest
    {
        private readonly DatabaseContext _context;

        public UserRequestService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Request>> GetRequestsList()
        {
            return await _context.Requests
                .ToListAsync();
        }

        public async Task<Request> GetRequestById(Guid id)
        {
            return await _context.Requests
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Request> CreateRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<int> UpdateRequest(Request request)
        {
            _context.Requests.Update(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteRequest(Request request)
        {
            _context.Requests.Remove(request);
            return await _context.SaveChangesAsync();
        }
    }
}

