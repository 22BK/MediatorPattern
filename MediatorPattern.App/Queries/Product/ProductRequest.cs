using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.App.Queries.Product
{
    public class ProductRequest : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}
