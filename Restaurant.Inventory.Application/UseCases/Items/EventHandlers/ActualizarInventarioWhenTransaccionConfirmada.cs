using MediatR;
using Restaurant.Inventory.Domain.Events;
using Restaurant.Inventory.Domain.Exceptions;
using Restaurant.Inventory.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Items.EventHandlers;

internal class ActualizarInventarioWhenTransaccionConfirmada
    : INotificationHandler<TransaccionConfirmada>
{
    private readonly IItemRepository _itemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActualizarInventarioWhenTransaccionConfirmada(IItemRepository itemRepository, 
        IUnitOfWork unitOfWork)
    {
        _itemRepository = itemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TransaccionConfirmada evento, CancellationToken cancellationToken)
    {
        foreach (var item in evento.Detalle)
        {
            var storedItem = await _itemRepository.FindByIdAsync(item.ItemId);
            if (storedItem == null)
            {
                throw new TransactionCreationException("Item con ID: " + item.ItemId + " no existe");
            }

            storedItem.ActualizarStockYCostoPromedio(item.Cantidad, item.CostoUnitario);

        }

        await _unitOfWork.Commit();


    }
}
