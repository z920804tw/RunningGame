using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;
    public GameObject platForm;
    public GameObject prePlatForm;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnNext()
    {
       GameObject pf= Instantiate(platForm,prePlatForm.transform.position+new Vector3(0,0,100),Quaternion.identity);
       pf.transform.SetParent(parent.transform);
       prePlatForm=pf;
    }
}
