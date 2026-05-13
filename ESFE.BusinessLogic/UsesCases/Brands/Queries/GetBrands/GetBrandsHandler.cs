using ESFE.BusinessLogic.DTOs;
using ESFE.DataAccess.Interfaces;
using ESFE.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESFE.BusinessLogic.UsesCases.Brands.Queries.GetBrands
{
    internal sealed class GetBrandsHandler(IEfRepository<Brand> _repository)
        : IRequestHandler<GetBrandsQuery, <List<BrandResponse>
    {
{
        public async Task<object> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
        {
            var brands = await _repository.ListAsync(cancellationToken);

            if (brands == null || !brands.Any())
            {
                return new List<BrandResponse>();
            }

            return brands.Adapt<List<BrandResponse>>();
        }
    }
}