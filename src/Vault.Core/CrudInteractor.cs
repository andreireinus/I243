﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class CrudInteractor<T> : ICrudInteractor<T> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;

        public CrudInteractor(IRepository<T> bookRepository)
        {
            _repository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public Task<OperationResult<T>> CreateAsync(T entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task<OperationResult<T>> UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task<OperationResult<T>> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public Task<OperationResult<T[]>> GetAllAsync()
        {
            var entities = _repository.Query().ToArray();

            return Task.FromResult(new OperationResult<T[]>(entities));
        }
    }
}