using System;
using System.Collections.Generic;
using System.Text;


namespace InventoryManager.Domain.Entities
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<List<Product>> GetAllAsync(
            CancellationToken cancellationToken = default);
            

        Task AddAsync (
            Product product, CancellationToken cancellationToken = default);

        void Update(Product product);
        void Delete(Product product);

        Task<bool> ExistsAsync(
            Guid id, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
//O domínio define o contrato.
//A infraestrutura implementa.