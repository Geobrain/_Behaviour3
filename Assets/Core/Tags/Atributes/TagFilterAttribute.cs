using UnityEngine;


public class TagFilterAttribute : PropertyAttribute
{
	private System.Type[] tagType;

	public System.Type[] Type => tagType;

	public TagFilterAttribute(params System.Type[] type)
	{
		tagType = type;
	}
}
