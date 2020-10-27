using MediatorPattern.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPattern.App.Queries.Users
{
    public class UserHandler:IRequestHandler<UserRequest,UserResponse>
    {
        private readonly PostgreDbContext _postgreDbContext;

        public UserHandler(PostgreDbContext postgreDbContext)
        {
            _postgreDbContext = postgreDbContext;
        }
        public async Task<UserResponse> Handle(UserRequest request,CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            UserResponse response = new UserResponse(); 
            response.User = _postgreDbContext.Users.FirstOrDefault(x=>x.Id==request.Id);
            return response;
        }
    }
}
