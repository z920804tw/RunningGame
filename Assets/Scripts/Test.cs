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
        isGround = CheckGround();
        Jump();        //跳躍功能
    }
    bool CheckGround() //檢查是否碰到地面
    {
        Collider[] collider = Physics.OverlapSphere(new Vector3(transform.position.x,transform.position.y-playerH,transform.position.z), 0.2f, ground);
        if (collider.Length != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Jump()
    {
        if (!isJump)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

                isJump = true;
            }
        }
        else if (isJump)
        {
            if (isGround && !wasGround)
            {

                isJump = false;
            }
        }
        wasGround = isGround;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y-playerH,transform.position.z), 0.2f);
    }
}
