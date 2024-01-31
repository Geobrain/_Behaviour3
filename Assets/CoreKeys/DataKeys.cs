using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;


[Serializable]
public partial class DataKeys
{
  [FieldKey(categoryName = "None")] public const string None = "None";
  [FieldKey(categoryName = "Unit")] public const string Hero = "Hero";
  [FieldKey(categoryName = "Unit/Mobs")] public const string Rabbit = "Rabbit";
}


[Serializable]
public class KeyFilter : PropertyAttribute
{
  public Type Type { get; private set; }

  public KeyFilter(Type type)
  {
    Type = type;
  }
}


[AttributeUsage(AttributeTargets.Field)]
public class FieldKeyAttribute : Attribute
{
  public string categoryName;
}
