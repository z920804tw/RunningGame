using UnityEngine;

public class SourceListUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] pages;
    [SerializeField] GameObject next;
    [SerializeField] GameObject prev;
    [SerializeField] int count;

    void Start()
    {
        count = 0;
    }

    public void Reset()
    {
        count = 0;
        prev.SetActive(false);
        next.SetActive(true);

        CloseAll();
        pages[count].SetActive(true);

    }
    public void NextPage()
    {
        if (count >= pages.Length - 1) return;
        else
        {
            count++;
            CloseAll();
            ResetBtn();
            pages[count].SetActive(true);

            next.SetActive(true);
            if (count == pages.Length - 1) next.SetActive(false);
        }
    }
    public void PrevPage()
    {
        if (count <= 0) return;
        else
        {
            count--;
            CloseAll();
            ResetBtn();
            pages[count].SetActive(true);

            if (count == 0) prev.SetActive(false);
        }
    }

    void ResetBtn()
    {
        next.SetActive(true);
        prev.SetActive(true);
    }
    void CloseAll()
    {

        foreach (GameObject i in pages)
        {
            i.SetActive(false);
        }
    }
}
