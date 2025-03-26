using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] Animator anim;
    public GameObject bg;
    public GameObject loadBar;
    public TMP_Text loadText;
    public Image loadImg;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Load(int i)
    {
        bg.SetActive(true);
        StartCoroutine(LoadLevel(i));
    }

    IEnumerator LoadLevel(int index)
    {

        anim.SetTrigger("Load");
        yield return new WaitForSecondsRealtime(1.5f);

        loadBar.SetActive(true);
        loadText.gameObject.SetActive(true);

        var scene = SceneManager.LoadSceneAsync(index);
        scene.allowSceneActivation = false;
        while (scene.progress < 0.9f)
        {
            loadImg.fillAmount = Mathf.MoveTowards(loadImg.fillAmount, scene.progress, 3 * Time.deltaTime);
            yield return null;
        }

        //讀取好後會先延遲1秒完成讀取，並切換關卡
        Time.timeScale = 1;
        loadImg.fillAmount = 1;
        yield return new WaitForSeconds(1);
        loadText.gameObject.SetActive(false);
        loadBar.SetActive(false);
        scene.allowSceneActivation = true;


    }

}
