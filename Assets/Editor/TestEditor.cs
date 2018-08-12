using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PhysicsTest))]
public class TestEditor : Editor
{
	Editor modelEditor;

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		PhysicsTest test = target as PhysicsTest;

		if (test.UsedModel != null)
		{
			EditorGUILayout.Space();

			EditorGUILayout.LabelField(test.UsedModel.name, EditorStyles.boldLabel);

			serializedObject.Update();

			CreateCachedEditor(test.UsedModel, null, ref modelEditor);

			modelEditor.OnInspectorGUI();

			serializedObject.ApplyModifiedProperties();
		}
	}
}
