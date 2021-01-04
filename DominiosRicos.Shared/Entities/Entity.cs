using Flunt.Notifications;
using System;

namespace DominiosRicos.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity(Guid id)
        {
            id = id == Guid.Empty ? Guid.NewGuid() : id;
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}