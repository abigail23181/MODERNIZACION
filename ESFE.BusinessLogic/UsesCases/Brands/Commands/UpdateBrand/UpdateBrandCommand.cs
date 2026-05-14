using ESFE.BusinessLogic.DTOs;

using MediatR;

namespace ESFE.BusinessLogic.UsesCases.Brands.Commands.UpdateBrand;

public record UpdateBrandCommand(UpdateBrandRequest Request) : IRequest<int>;