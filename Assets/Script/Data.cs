using System;
using UnityEngine;


[Serializable]
public class Data
{
    /// <summary>
    /// Данные типа строка
    /// </summary>
    [SerializeField]
    public string stringData;
    /// <summary>
    /// Даннные типа число с плавающей точкой
    /// </summary>
    [SerializeField]
    public float floatData;

    public Data(){}

    public Data(string s, float f)
    {
        stringData = s;
        floatData = f;
    }
}

