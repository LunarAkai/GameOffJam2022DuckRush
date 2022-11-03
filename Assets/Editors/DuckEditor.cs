/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SODuck))]
public class DuckEditor : Editor
{
    private SerializedObject so;
    private SerializedProperty duckName;
    private SerializedProperty duckSpeed;
    private SerializedProperty duckAttentionRadius;
    private SerializedProperty duckRotationSpeed;
    private SerializedProperty duckModel;
    private SerializedProperty duckFavoritFood;
    
    private void OnEnable()
    {
        so = serializedObject;
        duckName = so.FindProperty("duckName");
        duckSpeed = so.FindProperty("duckSpeed");
        duckAttentionRadius = so.FindProperty("duckAttentionRadius");
        duckRotationSpeed = so.FindProperty("duckRotationSpeed");
        duckModel = so.FindProperty("duckModel");
        duckFavoritFood = so.FindProperty("duckFavoritFood");
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label("Duck Editor");

        so.Update();
        
        EditorGUILayout.PropertyField(duckName); 
        EditorGUILayout.PropertyField(duckSpeed); 
        EditorGUILayout.PropertyField(duckAttentionRadius); 
        EditorGUILayout.PropertyField(duckRotationSpeed); 
        EditorGUILayout.PropertyField(duckModel); 
        EditorGUILayout.PropertyField(duckFavoritFood);

        so.ApplyModifiedProperties();





    }
}*/
