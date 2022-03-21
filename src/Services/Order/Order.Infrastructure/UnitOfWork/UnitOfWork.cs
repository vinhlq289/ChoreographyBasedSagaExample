﻿using Order.Domain.Common;
using Order.Infrastructure.Persistence;
using Order.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfCoreDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        public UnitOfWork(EfCoreDbContext dbContext)
        {
            this._dbContext = dbContext;

            this._orderRepository = new OrderRepository(this._dbContext);
        }

        public IOrderRepository OrderRepository => _orderRepository;

        public void SaveChanges()
        {
            this._dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }
    }
}
