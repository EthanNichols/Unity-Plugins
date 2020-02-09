using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// Editor class to draw a highlight box around a property in the inspector
/// </summary>
[CustomPropertyDrawer(typeof(PropertyColorAttribute))]
public class ColorAttributeDrawer : PropertyDrawer
{
		/// <summary>
		/// The width of the color box before the property label
		/// </summary>
		private const int PRE_LABEL_RECT_WIDTH = 5;
		/// <summary>
		/// The size of the border around the property
		/// </summary>
		private const int BORDER_SIZE = 1;
		/// <summary>
		/// Offset distance of the starting position to the field box of a property
		/// </summary>
		private const int PROPERTY_WIDTH_MARGIN = 2;


		/// <summary>
		/// Draw a rectangle around a property
		/// The rectangle is drawn around the position no inside or on the position
		/// </summary>
		/// <param name="position">The position of the property</param>
		/// <param name="color">The color that the rectangle will be drawn</param>
		/// <param name="borderSize">The size of the border around the property position</param>
		private void DrawRectangleBorder(Rect position, Color color, int borderSize)
		{
				// Calculate the top border rectangle
				Rect topBorder = position;
				topBorder.height = borderSize;
				topBorder.y -= borderSize;
				// Calculate the bottom border rectangle
				Rect bottomBorder = topBorder;
				bottomBorder.y += position.height + borderSize;

				// Calculate the left border rectangle
				Rect leftBorder = position;
				leftBorder.width = borderSize;
				leftBorder.height += borderSize * 2;
				leftBorder.y -= borderSize;
				leftBorder.x -= borderSize;
				// Calcualte the right border ractangle
				Rect rightBorder = leftBorder;
				rightBorder.x += position.width + borderSize;

				// Draw the rectangle borders
				EditorGUI.DrawRect(topBorder, color);
				EditorGUI.DrawRect(bottomBorder, color);
				EditorGUI.DrawRect(leftBorder, color);
				EditorGUI.DrawRect(rightBorder, color);
		}


		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
				// Get the color attribute
				PropertyColorAttribute attr = attribute as PropertyColorAttribute;

				// Calculate the rectangle around the property values
				Rect propertyRect = position;
				propertyRect.x += (EditorGUIUtility.labelWidth + PROPERTY_WIDTH_MARGIN) - BORDER_SIZE;
				propertyRect.width -= (EditorGUIUtility.labelWidth + PROPERTY_WIDTH_MARGIN) - BORDER_SIZE * 2;
				propertyRect.y -= BORDER_SIZE;
				propertyRect.height += BORDER_SIZE * 2;

				// Calculate the rectangle before the property label
				Rect preLabelRect = position;
				preLabelRect.width = PRE_LABEL_RECT_WIDTH;
				preLabelRect.x -= preLabelRect.width;

				// Draw the highlight
				DrawRectangleBorder(position, attr.propertyColor, 1);
				//EditorGUI.DrawRect(preLabelRect, attr.propertyColor);
				//EditorGUI.DrawRect(propertyRect, attr.propertyColor);

				//Draw the property
				EditorGUI.PropertyField(position, property, null);
		}
}
