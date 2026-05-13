using ESFE.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.BusinessLogic.UseCases.Brands.Queries.GetBrand;

public record GetBrandQuery(int brandId) : IRequest<BrandResponse>;