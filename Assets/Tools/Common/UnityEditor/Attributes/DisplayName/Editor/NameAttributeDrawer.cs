using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/// <summary>
/// Editor class to draw the new name of a property in the inspector
/// </summary>
[CustomPropertyDrawer(typeof(DisplayNameAttribute))]
public class NameAttributeDrawer : PropertyDrawer
{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
				DisplayNameAttribute attr = attribute as DisplayNameAttribute;
				label.text = attr.displayName;
				EditorGUI.PropertyField(position, property, label);
		}
}
