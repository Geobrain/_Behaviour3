using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
public sealed class ComponentBehaviors : Component{
  [FormerlySerializedAs("www")] public int test;

  public List<AbstractBehavior> behaviors = new(); // список поведений
  public AbstractBehavior activeBehavior;
}

#region HELPERS

public static partial class ComponentHelper {
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
  public static void CreateStorage() => StorageComponentBehaviors.Instance ??= new StorageComponentBehaviors();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ComponentBehaviors AddGetComponentBehaviors(this Ent entity) {
    var component = new ComponentBehaviors();
    StorageComponentBehaviors.Instance.AddComponent(entity, component);
    return component;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ComponentBehaviors ComponentBehaviors(this Ent entity) => StorageComponentBehaviors.Instance.Components[entity];

  /*[MethodImpl(MethodImplOptions.AggressiveInlining)] todo
  public static ComponentBehaviors TryGetComponentBehaviors(this Ent entity) => StorageComponentBehaviors.components[entity];*/
}


public sealed class StorageComponentBehaviors : ComponentStorage<ComponentBehaviors> {
  public override void AddComponent(Ent entity, Component component) => Instance.Components.TryAdd(entity, (ComponentBehaviors) component);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override void Dispose(Ent entity) {
    var component = Components[entity];
    component.test = 0;
    Components.Remove(entity);
  }
}

#endregion
