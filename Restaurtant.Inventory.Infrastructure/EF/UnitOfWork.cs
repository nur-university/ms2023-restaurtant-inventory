using MediatR;
using Restaurant.SharedKernel.Core;
using Restaurtant.Inventory.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurtant.Inventory.Infrastructure.EF
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IMediator _mediator;
        private readonly WriteDbContext _context;

        private int _transactionCounter;

        public UnitOfWork(WriteDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
            _transactionCounter = 0;
        }

        public async Task Commit()
        {
            _transactionCounter++;

            var domainEvents = _context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x =>
                {
                    var domainEvents = x.Entity
                                    .DomainEvents
                                    .ToImmutableArray();
                    x.Entity.ClearDomainEvents();

                    return domainEvents;
                })
                .SelectMany(domainEvents => domainEvents)
                .ToList();

            foreach (var evento in domainEvents)
            {
                await _mediator.Publish(evento);
            }

            if (_transactionCounter == 1)
            {
                await _context.SaveChangesAsync();
            }
            else
            {
                _transactionCounter--;
            }
        }
    }
}
