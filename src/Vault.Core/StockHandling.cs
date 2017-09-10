using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class StockHandling
    {
        private readonly ILibraryItemRepository _repository;

        public StockHandling(ILibraryItemRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public async Task<OperationResult<LibraryItem>> AddImageAsync(LibraryItem item, byte[] image)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (image == null || !image.Any())
            {
                throw new ArgumentNullException(nameof(image));
            }

            item = await _repository.GetAsync(item.Id);

            if (item == null)
            {
                return new OperationResult<LibraryItem>(new [] {"Library item not found in database."});
            }

            item.Pictures = item.Pictures ?? new List<Picture>();
            item.Pictures.Add(new Picture
            {
                Bytes = image,
                LibraryItem = item,
            });

            return await _repository.UpdateAsync(item);
        }
    }
}
