using CQRS.Interfaces;
using MediatR;

namespace CQRS.Features.Requests.Commands
{
    public class CreateRequestCommand : IRequest<Request>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RequestType { get; set; }
        public string RequestMessage { get; set; }

        public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Request>
        {
            private readonly IUserRequest _requestService;

            public CreateRequestCommandHandler(IUserRequest requestService)
            {
                _requestService = requestService;
            }

            public async Task<Request> Handle(CreateRequestCommand command, CancellationToken cancellationToken)
            {
                var request = new Request()
                {
                    Id = new Guid(),
                    Name = command.Name,
                    RequestType = command.RequestType,
                    RequestMessage = command.RequestMessage
                };

                return await _requestService.CreateRequest(request);
            }
        }
    }
}
