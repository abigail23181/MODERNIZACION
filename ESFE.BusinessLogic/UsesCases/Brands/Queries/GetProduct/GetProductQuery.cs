using ESFE.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESFE.BusinessLogic.UsesCases.Brands.Queries.GetProduct;

public record GetProductQuery(int ProductId) : IRequest<ProductByIdResponse>;
