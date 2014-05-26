using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Monitor))]
public class MonitorEditor : Editor
{
    private Vector2 _scrolPosition;
    Monitor monitor { get { return target as Monitor; } }

    //Интерфейс
    public override void OnInspectorGUI()
    {
        monitor.Fountainhead = (DataCollection) EditorGUILayout.ObjectField(monitor.Fountainhead, typeof(DataCollection), true);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Data: ");
        GUILayout.Label(monitor.Data.stringData + "  " + monitor.Data.floatData);
        EditorGUILayout.EndHorizontal();

        if (monitor.Fountainhead != null)
            if (monitor.Fountainhead.Datas != null)
            {
                foreach (var data in monitor.Fountainhead.Datas)
                {
                    if (data.Equals(monitor.Data)) monitor.Data = data;
                }
                if (monitor.Fountainhead.Datas.Length > 0)
                {
                    EditorGUILayout.BeginVertical("HelpBox", GUILayout.Height(300));
                    _scrolPosition = EditorGUILayout.BeginScrollView(_scrolPosition);

                    foreach (var data in monitor.Fountainhead.Datas)
                    {

                        EditorGUILayout.BeginHorizontal();
                        GUILayout.Label("Data :", GUILayout.Width(45));
                        data.stringData = GUILayout.TextField(data.stringData);
                        data.floatData = EditorGUILayout.FloatField(data.floatData, GUILayout.Width(100));
                        if (GUILayout.Button("v", GUILayout.Width(20)))
                        {
                            monitor.Data = data;
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndScrollView();
                    EditorGUILayout.EndHorizontal();
                }

            }
    }
}