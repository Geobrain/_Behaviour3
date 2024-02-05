using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static class ComponentsStorage
{
  public static List<ComponentStorage> ComponentStorage = new ();

  public static void DisposeComponents(this Ent entity)
  {
    foreach (var storage in ComponentStorage)
    {
      storage.Dispose(entity);
    }
  }

}

public abstract class ComponentStorage
{
  public abstract void Dispose(Ent entity);
}

public abstract class ComponentStorage<T> : ComponentStorage
{
  public static ComponentStorage<T> Instance;
  public Dictionary<Ent, T> Components = new ();

  protected ComponentStorage()
  {
    if (!ComponentsStorage.ComponentStorage.Contains(Instance))
    {
      ComponentsStorage.ComponentStorage.Add(Instance);
    }
  }

  public abstract T Create(Ent entity);

  /*
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public T TryGet(int entityID)
  {
    return (ProcessorEcs.EntitiesManaged[entityID].signature[Generation] & ComponentMask) == ComponentMask
      ? components[entityID]
      : default;
  }*/

}
