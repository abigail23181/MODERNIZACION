using ESFE.BusinessLogic.DTOs;
using ESFE.DataAccess.Interfaces;
using ESFE.DataAccess.Repositories;
using ESFE.Entities;
using Mapster;
using MediatR;

namespace ESFE.BusinessLogic.UseCases.Brands.Commands.CreateBrand;

public record CreateBrandCommand(CreateBrandRequest Request) : IRequest<int>;