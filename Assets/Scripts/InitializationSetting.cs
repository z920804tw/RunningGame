using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationSetting : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        if (PlayerPrefs.HasKey("initialization") == false)
        {
            //進行初始化 
            PlayerPrefs.SetInt("initialization", 1);
            //音量
            PlayerPrefs.SetFloat("MainVolume", 1);
            PlayerPrefs.SetFloat("MusicVolume", 1);
            PlayerPrefs.SetFloat("SfxVolume", 1);

            //解析度
            PlayerPrefs.SetInt("FullScreen", 1);
            PlayerPrefs.SetInt("ScreenResolutionX", Screen.currentResolution.width);
            PlayerPrefs.SetInt("ScreenResolutionY", Screen.currentResolution.height);

            Debug.Log("初始化完成");
        }
    }
}
