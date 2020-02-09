using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Attribute to highlight the area a property occupies in the inspector
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class PropertyColorAttribute : PropertyAttribute
{
		/// <summary>
		/// The color of the highlight rectangle
		/// </summary>
		public readonly Color propertyColor;

		/// <summary>
		/// Set the color of the border using <see cref="Color"/>
		/// </summary>
		/// <param name="color"></param>
		public PropertyColorAttribute(Color color)
		{
				color.a = 1.0f;
				propertyColor = color;
		}

		/// <summary>
		/// The color of the border using RGB
		/// </summary>
		/// <param name="r">Red value [0-1]</param>
		/// <param name="g">Blue value [0-1]</param>
		/// <param name="b">Green value [0-1]</param>
		public PropertyColorAttribute(float r, float g, float b)
		{
				propertyColor = new Color(r, g, b);
		}
}
