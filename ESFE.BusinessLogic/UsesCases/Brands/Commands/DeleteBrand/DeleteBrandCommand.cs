using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESFE.BusinessLogic.UsesCases.Brands.Commands.DeleteBrand
{
    public record DeleteBrandCommand(int brandId) : IRequest<int>
    {
    }
}
