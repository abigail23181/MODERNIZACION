using Ardalis.Specification.EntityFrameworkCore;
using ESFE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESFE.DataAccess.Interfaces
{
    public interface IEfRepository<T> : RepositoryBase<T>, IEfRepository<T> where T  : class 
    {
        Task AddAsync(Brand newBrand, CancellationToken cancellationToken);
        Task AddAsync(Brand newBrand);
        Task BeginTransactionAsync();

        Task CommitAsync();
        Task GetByIdAsync(object brandId);
        Task RollbackAsync();
        Task UpdateAsync(object existingBrand, CancellationToken cancellationToken);
    }
}
