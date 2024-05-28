using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
public class Menu : MonoBehaviour
{
    [SerializeField] TMP_Text level;
    public Scene level_1;
    public Scene level_2;
    [SerializeField] Button newgame;
    [SerializeField] Button startlevel;
    [SerializeField] Button right;
    [SerializeField] Button left;
    [SerializeField] Scene menu;
    [SerializeField] string[] levels;
    [SerializeField] int currentlevel;
    [SerializeField] AudioClip startsound;
    [SerializeField] AudioClip buttonsound;
    [SerializeField] Button loadgame;
    [SerializeField] DataControllerScript data;
    [SerializeField] MenuController ScreensControlller;
    [SerializeField] Button yes;
    [SerializeField] Button no;
    [SerializeField] LevelsData L_D;
    [SerializeField] Button exit;
    void Start()
    {
        L_D = GameObject.FindGameObjectWithTag("LevelsData").GetComponent<LevelsData>();
        ScreensControlller = GameObject.FindGameObjectWithTag("menuController").GetComponent<MenuController>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataControllerScript>();
        levels = new string[] {"Level1"};
        loadgame.onClick.AddListener(loadgame_);
        right.onClick.AddListener(plus);
        left.onClick.AddListener(minus);
        newgame.onClick.AddListener(levelselect);
        startlevel.onClick.AddListener(startlevel_event);
        yes.onClick.AddListener(newgame_);
        no.onClick.AddListener(previous);
        exit.onClick.AddListener(Quit);
    }
    
    void Update()
    {
        // if (currentlevel! < levels.Length && currentlevel! > levels.Length)
        //{
        //  level.text = ("nivel" + currentlevel + 1);
        //}
        L_D.Clevel = currentlevel;
        level.text = levels[currentlevel];
        if (L_D.Levels == 0)
        {
            levels = new string[] { "Level1" }; ;
        }
        if (L_D.Levels == 1)
        {
            levels = new string[] { "Level1","Level2" };
        }
        if (L_D.Levels == 2)
        {
            levels = new string[] { "Level1", "Level2","Level3" };
        }
    }
    void plus()
    {
        SoundController.Instance.PlaySound(buttonsound);
        currentlevel++;
        if (currentlevel > levels.Length - 1)
        {
            currentlevel -= levels.Length;
        }
        else
        {
        }     
        }
    void minus()
    { 
    SoundController.Instance.PlaySound(buttonsound);
        if (currentlevel == 0)
        {
            currentlevel += levels.Length-1;
        }
        else
        {
            currentlevel--;
        }
    }
    void loadgame_()
    {
       data.LoadData();
        if (L_D.Levels == 0)
        { }
        else { 
            ScreensControlller.CurrentScreenNumber = 1;
        }
    }
    void levelselect()
    {
        DataControllerScript.Instance.LoadData();
        if (L_D.Levels==0)
        {
            newgame_();
        }
        else
        {
            ScreensControlller.CurrentScreenNumber = 2;
        }
    }
    void startlevel_event()
    {
        SoundController.Instance.PlaySound(buttonsound);
        SceneManager.LoadScene("level"+(currentlevel+1),LoadSceneMode.Single); }
    void previous()
    {
        ScreensControlller.CurrentScreenNumber -= 2;
    }
    void newgame_()
    {
        LevelsData.Instance.Levels = 0;
        data.SaveData();
        SceneManager.LoadScene("level1");
        L_D.Clevel = 0;
    }
    private void Quit()
    {
        Application.Quit();
    }
}
