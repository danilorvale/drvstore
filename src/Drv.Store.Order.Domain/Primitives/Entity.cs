﻿namespace Drv.Store.Order.Domain.Primitives;

public class Entity
{
    protected Entity(Guid id) => Id = id;

    public Guid Id { get; protected set; }
}