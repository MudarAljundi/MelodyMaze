﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LocalizationTextEditor : EditorWindow {

	public LocalizationData localizationData;

	private Vector2 scrollPos;

	[MenuItem("Alex/Localization Text Editor")]
	static void Init() {
		EditorWindow.GetWindow(typeof(LocalizationTextEditor)).Show();
	}

	private void OnGUI() {
		if (localizationData != null) {

			scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
			
			SerializedObject serializedObject = new SerializedObject(this);
			SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");
			EditorGUILayout.PropertyField(serializedProperty, true);

			EditorGUILayout.EndScrollView();

			serializedObject.ApplyModifiedProperties();


			if (GUILayout.Button ("Save data")) {
				SaveGameData();
			}
		}

		if (GUILayout.Button ("Load data")) {
			LoadGameData();
		}
		if (GUILayout.Button("Create new data")) {
			CreateNewData();
		}
	}

	private void SaveGameData() {
		string filePath = EditorUtility.SaveFilePanel("Save localization data file", Application.streamingAssetsPath, "save1", "json");

		if (!string.IsNullOrEmpty(filePath)) {
			string data_Json = JsonUtility.ToJson(localizationData);
			File.WriteAllText(filePath, data_Json);
		}
	}
	private void LoadGameData() {
		string filePath = EditorUtility.OpenFilePanel("Select localization data File", Application.streamingAssetsPath, "json");

		if (!string.IsNullOrEmpty(filePath)) {
			string data_Json = File.ReadAllText(filePath);

			localizationData = JsonUtility.FromJson<LocalizationData>(data_Json);
		}
	}
	private void CreateNewData() {
		localizationData = new LocalizationData();
	}
}
