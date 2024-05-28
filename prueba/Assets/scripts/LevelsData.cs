using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsData : MonoBehaviour
{
    public static LevelsData Instance;
    public int Levels;
    public int Clevel;
    public int CounterLevel1;
    public int CounterLevel2;
    public int CounterLevel3;
    private void Awake()
    {
        if (LevelsData.Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            LevelsData.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Add_Counter(int added)
    {
        Levels +=added;
    }
    public void Set_Counter(int added)
    {
        Levels = added;
    }
}
