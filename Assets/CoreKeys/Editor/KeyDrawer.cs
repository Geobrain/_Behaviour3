using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(KeyFilter))]
public class KeyDrawer : PropertyDrawer
{
  public int currentIndex;
  public StringBuilder fs = new StringBuilder(128);
  public List<FieldInfo> fields = new List<FieldInfo>();

  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {
    EditorGUI.BeginProperty(position, label, property);

    var tagFilter = attribute as KeyFilter;
    var tagType = tagFilter.Type;

    var objectFields = ReturnConst(tagType);

    var listNames = new List<string>();
    fields.Clear();

    var vv = property.stringValue;

    for (var i = 0; i < objectFields.Length; i++)
    {
      var myFieldInfo = objectFields[i];
      var tagField = Attribute.GetCustomAttribute(objectFields[i], typeof(FieldKeyAttribute)) as FieldKeyAttribute;

      if (tagField == null) continue;
      fs.Append(tagField.categoryName).Append("/").Append(myFieldInfo.Name);
      listNames.Add(fs.ToString());
      fs.Length = 0;
      fields.Add(myFieldInfo);
      if (vv == (string) myFieldInfo.GetValue(this)) currentIndex = fields.Count - 1;
    }

    if (listNames.Count == 0)
    {
      EditorGUI.EndProperty();
      return;
    }

    currentIndex = EditorGUI.Popup(position, property.displayName, currentIndex, listNames.ToArray());

    var raw = listNames[currentIndex].Split('/');
    var name = raw[raw.Length - 1];

    var field = fields.Find(f => f.Name == name);
    property.stringValue = (string) field.GetValue(this);

    EditorGUI.EndProperty();
  }


  FieldInfo[] ReturnConst(Type t)
  {
    ArrayList constants = new ArrayList();

    FieldInfo[] fieldInfos = t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

    foreach (FieldInfo fi in fieldInfos)
      if (fi.IsLiteral && !fi.IsInitOnly)
        constants.Add(fi);
    return (FieldInfo[]) constants.ToArray(typeof(FieldInfo));
  }
}