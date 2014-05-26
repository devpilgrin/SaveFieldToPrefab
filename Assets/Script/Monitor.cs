using UnityEngine;

public class Monitor : MonoBehaviour
{
    //Источник данных
    [SerializeField]
    public DataCollection Fountainhead;

    public Data Data;

    //Проверка на соответствие данных
    public void Start()
    {
        if (Data != null)
        {
            foreach (Data data in Fountainhead.Datas)
            {
                if (data.Equals(Data)) Data = data;
            }
        }
    }
}