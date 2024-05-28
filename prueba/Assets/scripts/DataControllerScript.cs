using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataControllerScript : MonoBehaviour
{
    public static DataControllerScript Instance;
    [SerializeField] Data data = new Data();
    public string SavedData;
    [SerializeField] Button newgame;
    [SerializeField] Button loadgame;
    void Start()
    {
        SavedData = Application.dataPath + "/SavedData.json";
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
public void SaveData() 
    {
        Data newdata = new Data()
        {
            levels = LevelsData.Instance.Levels
        };
        string JSON = JsonUtility.ToJson(newdata);
        File.WriteAllText(SavedData, JSON);
        Debug.Log("Saved" + SavedData);
        Debug.Log("levels" + LevelsData.Instance.Levels);
    }
   public  void LoadData()
    {
        if (File.Exists(SavedData))
        {
           string content = File.ReadAllText(SavedData);
            data = JsonUtility.FromJson<Data>(content);
            Debug.Log("levels:"+content);
            LevelsData.Instance.Levels = data.levels;
        }
        else
        {
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            
        }
    }
}
