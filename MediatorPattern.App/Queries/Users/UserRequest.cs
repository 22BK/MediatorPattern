using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.App.Queries.Users
{
    public class UserRequest :IRequest<UserResponse>
    {
        public int Id { get; set; }
    }
}
