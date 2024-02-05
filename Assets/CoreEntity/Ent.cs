using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ent
{

    public abstract void Setup(Ent ent);

    public virtual void Destroy()
    {
        ProcessorBehaviors.Instance?.RemoveEntity(this);
        this.DisposeComponents();
        //Destroy(this);
    }
}
