using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] pages;
    public LoadingUI loadingUI;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(int i)
    {
        loadingUI.Load(i);
    }

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
}
