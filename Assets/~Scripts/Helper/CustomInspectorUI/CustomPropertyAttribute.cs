#if UNITY_EDITOR
using UnityEngine;

public sealed class CustomPropertyAttribute : PropertyAttribute
{
	public readonly string propertyName;
	public bool dirty;

	public CustomPropertyAttribute(string name)
	{
		propertyName = name;
	}
}
#endif