using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[CustomEditor(typeof (DataCollection))]
public class DataCollectionEditor : Editor
{    
    Vector2 _scrolPosition = new Vector2(0,0);
    DataCollection _dataCollection { get { return target as DataCollection; } }

    
    public override void OnInspectorGUI()
    {
        if (_dataCollection.Datas != null)
            if (_dataCollection.Datas.Length > 0)
            {
                EditorGUILayout.BeginVertical("HelpBox", GUILayout.Height(300));
                _scrolPosition = EditorGUILayout.BeginScrollView(_scrolPosition);

                foreach (var data in _dataCollection.Datas)
                {
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Label("Data :", GUILayout.Width(45));
                    data.stringData = GUILayout.TextField(data.stringData);
                    data.floatData = EditorGUILayout.FloatField(data.floatData, GUILayout.Width(100));
                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.EndScrollView();
                EditorGUILayout.EndHorizontal();
            }

        if(GUILayout.Button("Generate data")) 
            if (_dataCollection != null) 
                Generate();
    }

    //Генерация тестовых данных
	void Generate()
    {
        var rand = Random.Range(50, 100);
        _dataCollection.Datas = new Data[rand];

        for (int index = 0; index < rand; index++)
        {
            Char[] _char = {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                'w', 'x', 'y', 'z'
            };

            var text = String.Empty;
            for (var i = 0; i < Random.Range(10, 50); i++)
            {
                text += _char[Random.Range(0, 25)];
            }

            _dataCollection.Datas[index] = (new Data(text, Random.Range(-999999.999999f, 999999.999999f)));
        }
    }  





}