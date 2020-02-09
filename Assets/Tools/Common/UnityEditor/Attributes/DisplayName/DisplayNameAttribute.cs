using System;
using UnityEngine;


/// <summary>
/// Attribute to change the display name of a property in the inspector
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class DisplayNameAttribute : PropertyAttribute
{
		/// <summary>
		/// The name that the property will be names in the inspector
		/// </summary>
		public readonly string displayName;


		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="name">The display name of the property in the editor</param>
		public DisplayNameAttribute(string name)
		{
				displayName = name;
		}
}
