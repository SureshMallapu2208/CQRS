using CQRS.Interfaces;
using MediatR;


namespace CQRS.Features.Requests.Queries
{
    public class GetAllRequestsQuery : IRequest<IEnumerable<Request>>
    {
        public class GetAllPlayersQueryHandler : IRequestHandler<GetAllRequestsQuery, IEnumerable<Request>>
        {
            private readonly IUserRequest _requestService;

            public GetAllPlayersQueryHandler(IUserRequest requestService)
            {
                _requestService = requestService;
            }

            public async Task<IEnumerable<Request>> Handle(GetAllRequestsQuery query, CancellationToken cancellationToken)
            {
                return await _requestService.GetRequestsList();
            }
        }
    }
}
