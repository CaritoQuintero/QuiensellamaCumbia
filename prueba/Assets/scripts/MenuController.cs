using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public int CurrentScreenNumber = -2;
    GameObject[] Screens;

    void Start()
    {
        Screens = new GameObject[] {
           GameObject.FindGameObjectWithTag("intro"),
           GameObject.FindGameObjectWithTag("screen1"),
           GameObject.FindGameObjectWithTag("screen2"),
           GameObject.FindGameObjectWithTag("screen3"),
        };
    }

    void Update()
    {
        if (CurrentScreenNumber == -1)
        {
            for (int i = 0; i < Screens.Length; i++)
            {
                if (Screens[i] == Screens[0])
                {
                    Screens[i].SetActive(true);
                }
                else
                {
                    Screens[i].SetActive(false);
                }
            }
        }
        if (CurrentScreenNumber == 0)
        {
            for (int i = 0; i < Screens.Length; i++)
            {
                if (Screens[i] == Screens[1])
                {
                    Screens[i].SetActive(true);
                }
                else
                {
                    Screens[i].SetActive(false);
                }
            }
        }
        if (CurrentScreenNumber == 1)
        {
            for (int i = 0; i < Screens.Length; i++)
            {
                if (Screens[i] == Screens[2])
                {
                    Screens[i].SetActive(true);
                }
                else
                {
                    Screens[i].SetActive(false);
                }
            }
        }
        if (CurrentScreenNumber == 2)
        {
            for (int i = 0; i < Screens.Length; i++)
            {
                if (Screens[i] == Screens[3])
                {
                    Screens[i].SetActive(true);
                }
                else
                {
                    Screens[i].SetActive(false);
                }
            }
        }
        if (CurrentScreenNumber == 3)
        {
            for (int i = 0; i < Screens.Length; i++)
            {
                if (Screens[i] == Screens[4])
                {
                    Screens[i].SetActive(true);
                }
                else
                {
                    Screens[i].SetActive(false);
                }
            }
        }
    }
    GameObject GetScreen(string tag)
    {
        return GameObject.FindGameObjectWithTag(tag);
    }
}
