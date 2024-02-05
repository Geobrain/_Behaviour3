using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;


public static class HelperTags
{
  public static string TagToString(this int tag)
  {
    var members = GetMembersDict();
    return members.ContainsKey(tag) ? members[tag] : default;
  }  

  #region Reflection methods

#if UNITY_EDITOR
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
#endif
  static Dictionary<int, string> GetMembersDict()
  {
    var members = new Dictionary<int, string>();
    var typeTag = GetTypeTag();

    foreach (var type in typeTag)
    {
      var memberArray = type.GetMembers();

      foreach (var member in memberArray)
      {
        if (member.DeclaringType != null && member.DeclaringType.ToString() == type.FullName)
        {
          var field = member.GetValue(member);

          if (field != null)
          {
            var value = int.Parse(field.ToString());

            if (members.ContainsKey(value))
            {
              Debug.LogError($"[Tags] {member.Name} дублирует id: {value}");
            } 
            else
            {
              members.Add(value, member.Name);
            }
          }
        }
      }
    }

    return members;
  }  
  
  static List<Type> GetTypeTag()
  {
    var type = typeof(ITag);
    var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
      .SelectMany(a => a.GetTypes())
      .Where(t => type.IsAssignableFrom(t)).ToList();
    return types;
  }  
  
  static object GetValue(this MemberInfo memberInfo, object forObject)
  {
    switch (memberInfo.MemberType)
    {
      case MemberTypes.Field:
        return ((FieldInfo)memberInfo).GetValue(forObject);
      case MemberTypes.Property:
        return ((PropertyInfo)memberInfo).GetValue(forObject);
      default:
        return default;
    }
  } 

  #endregion

}
