using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(SquaredValueAttribute))]
public class SquaredValueDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		float value = property.floatValue;

		value = Mathf.Sqrt(value);

		string labelText = label.text.Replace("Squared", "").Replace("squared", "").Replace("sqr", "");

		label = new GUIContent(labelText);

		value = EditorGUI.FloatField(position, label, value);

		property.floatValue = Mathf.Pow(value, 2);
	}
}

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		GUI.enabled = false;
		EditorGUI.PropertyField(position, property, label, true);
		GUI.enabled = true;
	}
}