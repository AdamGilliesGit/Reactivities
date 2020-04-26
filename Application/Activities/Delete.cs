using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // get the activity to be Deleted
                var activity = await _context.Activities.FindAsync(request.Id);
                // check for null (invalid request of activity)
                if (activity == null)
                    throw new RestException(HttpStatusCode.NotFound, new {activity = "Not found."} );

                _context.Remove(activity);

                // check that success > 0 ie a change has been made and acitivity has been created.
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes.");
            }
        }

    }
}