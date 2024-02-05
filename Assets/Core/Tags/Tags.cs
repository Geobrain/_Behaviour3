using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;
using System.Reflection;


/// <summary>
/// Semples:
/// [TagFilter(typeof(Tags))] public int loop;
/// [TagField(categoryName = "TagCore/System")] public const int SET_ODER_HIDDEN_OBJECT = 20;
/// </summary>
public partial class Tags : ITag
{
  public const int None = -100;
  
  [TagField(categoryName = "Core")] public const int isCoreTag = -20;
  [TagField(categoryName = "Core/System")] public const int isTag2 = -40;
  [TagField(categoryName = "Id/editor")] public const int isTag334 = -50;
}



