using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Serialization;


[Serializable]
public sealed class ComponentBehaviors {
  [FormerlySerializedAs("www")] public int test;

  public List<AbstractBehavior> behaviors = new(); // список поведений
  public AbstractBehavior activeBehavior;
}

#region HELPERS

public static partial class Component {
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ComponentBehaviors AddGetComponentBehaviors(this Ent entity) {
    var component = new ComponentBehaviors();
    StorageComponentBehaviors.AddComponent(() => StorageComponentBehaviors.Instance.Components.TryAdd(entity, component));
    return component;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ComponentBehaviors ComponentBehaviors(this Ent entity) => StorageComponentBehaviors.Instance.Components[entity];

  /*[MethodImpl(MethodImplOptions.AggressiveInlining)] todo
  public static ComponentBehaviors TryGetComponentBehaviors(this Ent entity) => StorageComponentBehaviors.components[entity];*/
}


sealed class StorageComponentBehaviors : ComponentStorage<ComponentBehaviors> {
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public StorageComponentBehaviors() {
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override void Dispose(Ent entity) {
    var component = Components[entity];
    component.test = 0;
    Components.Remove(entity);
  }
}

#endregion
