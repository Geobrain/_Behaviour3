using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ent : Object
{
    protected Ent()
    {
        Setup();
    }

    protected abstract void Setup();

    public virtual void Destroy()
    {
        this.DisposeComponents();
        Destroy(this);
    }
}
