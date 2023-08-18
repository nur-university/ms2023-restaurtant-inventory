using Moq;
using Restaurant.Inventory.Application.UseCases.Items.EventHandlers;
using Restaurant.Inventory.Domain.Events;
using Restaurant.Inventory.Domain.Exceptions;
using Restaurant.Inventory.Domain.Factories;
using Restaurant.Inventory.Domain.Model.Items;
using Restaurant.Inventory.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Xunit;
using static Restaurant.Inventory.Domain.Events.TransaccionConfirmada;

namespace Restaurant.Test.Application.UseCases.Items.EventHandlers
{
    public class ActualizarInventarioWhenTransaccionConfirmada_Test
    {
        Mock<IItemRepository> _itemRepository;
        Mock<IUnitOfWork> _unitOfWork;

        public ActualizarInventarioWhenTransaccionConfirmada_Test()
        {
            _itemRepository = new Mock<IItemRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void ActualizacionValidaDeStock()
        {
            var items = ItemMockFactory.getItems();
            var item = items[0];
            var item2 = items[1];
            var item3 = items[2];
            Guid transaccionId = Guid.NewGuid();

            int valorEsperado1 = 10;
            int valorEsperado2 = 20;
            int valorEsperado3 = 30;

            var detalleTransaccion = new List<DetalleTransaccionConfirmada>
                {
                    new DetalleTransaccionConfirmada(item.Id, valorEsperado1, 10),
                    new DetalleTransaccionConfirmada(item2.Id, valorEsperado2, 20),
                    new DetalleTransaccionConfirmada(item3.Id, valorEsperado3, 30)
                };


            _itemRepository.Setup(_itemRepository => _itemRepository.FindByIdAsync(item.Id))
                .ReturnsAsync(item);
            _itemRepository.Setup(_itemRepository => _itemRepository.FindByIdAsync(item2.Id))
                .ReturnsAsync(item2);
            _itemRepository.Setup(_itemRepository => _itemRepository.FindByIdAsync(item3.Id))
                .ReturnsAsync(item3);

            var handler = new ActualizarInventarioWhenTransaccionConfirmada(
                _itemRepository.Object,
                _unitOfWork.Object
            );
            var tcs = new CancellationTokenSource(1000);

            TransaccionConfirmada evento = new TransaccionConfirmada(
                transaccionId,
                detalleTransaccion
            );
            handler.Handle(evento, tcs.Token);


            Assert.Equal(valorEsperado1, item.Stock);
            Assert.Equal(valorEsperado2, item2.Stock);
            Assert.Equal(valorEsperado3, item3.Stock);
        }
        [Fact]
        public void ActualizacionDeStockMultiple()
        {
            var items = ItemMockFactory.getItems();
            var item = items[0];
            Guid transaccionId = Guid.NewGuid();

            int valorEsperado1 = 30;

            var detalleTransaccion1 = new List<DetalleTransaccionConfirmada>
                {
                    new DetalleTransaccionConfirmada(item.Id, 10, 10)
                };
            var detalleTransaccion2 = new List<DetalleTransaccionConfirmada>
                {
                    new DetalleTransaccionConfirmada(item.Id, 20, 10)
                };


            _itemRepository.Setup(_itemRepository => _itemRepository.FindByIdAsync(item.Id))
                .ReturnsAsync(item);

            var handler = new ActualizarInventarioWhenTransaccionConfirmada(
                _itemRepository.Object,
                _unitOfWork.Object
            );
            var tcs = new CancellationTokenSource(1000);

            TransaccionConfirmada evento1 = new TransaccionConfirmada(
                transaccionId,
                detalleTransaccion1
            );
            handler.Handle(evento1, tcs.Token);

            TransaccionConfirmada evento2 = new TransaccionConfirmada(
                transaccionId,
                detalleTransaccion2
            );
            handler.Handle(evento2, tcs.Token);


            Assert.Equal(valorEsperado1, item.Stock);
        }
        [Fact]
        public void ItemNoEncontrado()
        {

            Guid transaccionId = Guid.NewGuid();
            Guid itemId = Guid.NewGuid();
            var detalleTransaccion = new List<DetalleTransaccionConfirmada>
                {
                    new DetalleTransaccionConfirmada(itemId, 10, 10)
                };
            Item? item = null;

            _itemRepository.Setup(_itemRepository => _itemRepository.FindByIdAsync(itemId))
                .ReturnsAsync(item);

            var handler = new ActualizarInventarioWhenTransaccionConfirmada(
                _itemRepository.Object,
                _unitOfWork.Object
            );
            var tcs = new CancellationTokenSource(1000);

            TransaccionConfirmada evento = new TransaccionConfirmada(
                transaccionId,
                detalleTransaccion
            );

            Assert.ThrowsAsync<TransactionCreationException>(() => handler.Handle(evento, tcs.Token));

        }
    }
}