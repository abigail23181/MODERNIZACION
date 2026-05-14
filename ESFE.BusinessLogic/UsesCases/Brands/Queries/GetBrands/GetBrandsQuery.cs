using ESFE.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.BusinessLogic.UsesCases.Brands.Queries.GetBrands;

    public record GetBrandsQuery() : IRequest<List<BrandResponse>>; 