using System;
using System.Runtime.CompilerServices;

  
  [Serializable]
  public sealed class ComponentBehaviors
  {
    public int www;
  }

  #region HELPERS

  public static partial class Component
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddComponentBehaviors(this Ent entity, ComponentBehaviors component)  
      => StorageComponentBehaviors.AddComponent(() => StorageComponentBehaviors.Instance.Components.TryAdd(entity, component)); // todo

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ComponentBehaviors ComponentBehaviors(this Ent entity) => StorageComponentBehaviors.Instance.Components[entity];
    
    /*[MethodImpl(MethodImplOptions.AggressiveInlining)] todo
    public static ComponentBehaviors TryGetComponentBehaviors(this Ent entity) => StorageComponentBehaviors.components[entity];*/
  }

  
  sealed class StorageComponentBehaviors : ComponentStorage<ComponentBehaviors>
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public StorageComponentBehaviors() { }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override void Dispose(Ent entity)
    {
      var component = Components[entity];
      component.www = 0;
      Components.Remove(entity);
    }
  }
  

  #endregion
