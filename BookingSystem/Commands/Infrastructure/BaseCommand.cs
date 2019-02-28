using System;
using BookingSystem.ApplicationCore.Interfaces;

namespace BookingSystem.Commands.Infrastructure
{
    public class BaseCommand<T> : ICommand<T>
    {
        public Guid Id { get; } = new Guid();
        public DateTime CreateDate { get; } = DateTime.UtcNow;
    }
}
