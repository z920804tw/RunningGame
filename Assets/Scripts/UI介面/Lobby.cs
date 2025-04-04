using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] pages;
    public GameObject exitPage;
    public void OpenPage(int i)
    {
        CloseAllpage();
        pages[i].SetActive(true);
    }
    void CloseAllpage()
    {
        foreach (GameObject i in pages)
        {
            i.SetActive(false);
        }
    }

    public void OpenExit()
    {
        exitPage.SetActive(true);
    }
    public void CloseExit()
    {
        exitPage.SetActive(false);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
