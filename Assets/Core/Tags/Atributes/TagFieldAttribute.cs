using System;


[AttributeUsage(AttributeTargets.Field)]
public class TagFieldAttribute : Attribute
{
  public string categoryName;
  public string className;

  public TagFieldAttribute(string categoryName, Type clas)
  {
    this.categoryName = categoryName;
    className = clas.ToString();
  }

  public TagFieldAttribute(Type clas, string categoryName)
  {
    this.categoryName = categoryName;
    className = clas.ToString();
  }

  public TagFieldAttribute(string categoryName)
  {
    this.categoryName = categoryName;
  }

  public TagFieldAttribute(Type clas)
  {
    className = clas.ToString();
  }

  public TagFieldAttribute()
  {
  }
}