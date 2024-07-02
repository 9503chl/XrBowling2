﻿using UnityEditor;
using UnityEngine;

namespace UnityEngine.UI
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(SpriteLoader), true)]
    public class SpriteLoaderInspector : Editor
    {
        private bool modified;
        private bool required;
        private bool loaded;

        private void OnEnable()
        {
            // Load all resources when inspector got focus
            foreach (SpriteLoader loader in targets)
            {
                loader.Load();
            }
        }

        private void OnDisable()
        {
            // Unload all resources when inspector lost focus
            foreach (SpriteLoader loader in targets)
            {
                loader.Unload();
            }
        }

        public override void OnInspectorGUI()
        {
            // Draw default inspector when "Script" is missing or null
            if (target == null)
            {
                base.OnInspectorGUI();
                return;
            }

            // Update SerializedObject and get first property
            serializedObject.Update();
            SerializedProperty property = serializedObject.GetIterator();
            property.NextVisible(true);

            // Does not draw "Script" property
            EditorGUILayout.Space();

            modified = false;
            required = false;
            loaded = false;

            // Draw other properties
            while (property.NextVisible(false))
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(property, true);
                if (EditorGUI.EndChangeCheck())
                {
                    modified = true;
                    serializedObject.ApplyModifiedProperties();
                }
            }

            // Draw preview
            int rowCount = 0;
            GUILayout.BeginHorizontal();
            foreach (SpriteLoader loader in targets)
            {
                if (loader.GetComponent<Image>() == null && loader.GetComponent<RawImage>() == null && loader.GetComponent<SpriteRenderer>() == null)
                {
                    required = true;
                }
                else
                {
                    if (modified)
                    {
                        loader.Load();
                    }

                    GUIContent preview = loader.Preview;
                    if (preview != null)
                    {
                        loaded = true;
                        GUILayout.FlexibleSpace();
#if UNITY_2019_3_OR_NEWER
                        EditorGUILayout.HelpBox(preview);
#else
                        GUILayout.Box(preview);
#endif
                        GUILayout.FlexibleSpace();

                        if (modified && loader.enabled)
                        {
                            loader.Apply();
                        }

                        if (++rowCount % 2 == 0)
                        {
                            GUILayout.EndHorizontal();
                            GUILayout.BeginHorizontal();
                        }
                    }
                }
            }
            GUILayout.EndHorizontal();

            if (required)
            {
                EditorGUILayout.HelpBox("Image, RawImage or SpriteRenderer component is required!", MessageType.Warning);
            }
            else if (!loaded)
            {
                EditorGUILayout.HelpBox("Sprite not found in resources.", MessageType.Info);
            }
        }
    }
}
