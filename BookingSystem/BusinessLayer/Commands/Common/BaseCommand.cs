using System;
using MediatR;

namespace BusinessLayer.Commands.Common
{
    public class BaseCommand<T> : IRequest //: IRequest<T>
    {
        public Guid Id { get; } = new Guid();
        public DateTime CreateDate { get; } = DateTime.UtcNow;
    }
}
