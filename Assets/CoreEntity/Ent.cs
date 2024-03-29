using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ent : Object
{
    public int Id { get; private set; }

    protected Ent()
    {
        Setup();
    }

    protected abstract void Setup();

    public virtual void Destroy()
    {
        ProcessorBehaviors.Instance?.RemoveEntity(this);
        this.DisposeComponents();
        Destroy(this);
    }
}
