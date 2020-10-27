using MediatorPattern.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPattern.App.Queries.Product
{
    public class ProductHandler : IRequestHandler<ProductRequest, ProductResponse>
    {
        private readonly MediatorDBContext _mediatorDBContext;

        public ProductHandler(MediatorDBContext mediatorDBContext)
        {
            _mediatorDBContext = mediatorDBContext;
        }

        public async Task<ProductResponse> Handle(ProductRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            ProductResponse response = new ProductResponse();
            response.Product = _mediatorDBContext.Products.FirstOrDefault(x => x.Id == request.Id);
            return response;
        }
    }
}
