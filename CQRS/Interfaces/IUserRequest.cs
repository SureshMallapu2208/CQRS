namespace CQRS.Interfaces
{
    public interface IUserRequest
    {
        Task<IEnumerable<Request>> GetRequestsList();
        Task<Request> GetRequestById(Guid id);
        Task<Request> CreateRequest(Request request);
        Task<int> UpdateRequest(Request request);
        Task<int> DeleteRequest(Request request);
    }
}
