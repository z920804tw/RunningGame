using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float jumpForce;
    [SerializeField] LayerMask ground;
    [SerializeField] float playerH;

    [SerializeField] bool isJump;
    [SerializeField] bool isGround;
    bool wasGround;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.Raycast(transform.position, transform.up * -1, playerH);
        Debug.DrawRay(transform.position,transform.up*-playerH,Color.red);
        if (isGround)
        {
            Jump();        //跳躍功能
        }
        wasGround = isGround;
    }
    void Jump()
    {
        if (!isJump)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                Debug.Log("Jump");
                isJump = true;
            }
        }
        else if (isJump && !wasGround)
        {
            isJump = false;
            Debug.Log("Ground");
        }
    }
}
