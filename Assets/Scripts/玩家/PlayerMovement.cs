using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("物件設定")]
    public Animator anim;
    Rigidbody rb;
    CapsuleCollider capsuleCollider;

    [Header("移動參數設定")]
    public float moveSpeed;

    [Header("跳躍參數設定")]
    public float jumpForce;
    [SerializeField] LayerMask ground;
    [SerializeField] Vector3 checkOffset;
    [SerializeField] bool isJump;
    [SerializeField] bool isGround;
    [SerializeField] bool wasGround;
    [Header("滑行參數設定")]
    [SerializeField] float slideHight;
    [SerializeField] Vector3 slideCenter;
    float defaultHight;
    Vector3 defaultCenter;
    [SerializeField] bool isSlide;
    float slideTime;

    [Header("跑道參數設定")]
    public float lineDirection;
    [SerializeField] int maxLineNum;
    [SerializeField] int lineNum;
    Vector3 targetPos;
    Vector3 startPos;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }
    void OnDisable()
    {
        rb.velocity = new Vector3(0, 0, 5f);
    }
    void Start()
    {
        lineNum = maxLineNum / 2;
        targetPos = new Vector3(0, transform.position.y, transform.position.z);
        startPos = transform.position;

        defaultHight = capsuleCollider.height;
        defaultCenter = capsuleCollider.center;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.position.x,transform.position.y,startPos.z);
        isGround = CheckGround();
        if (isGround)
        {
            Jump();        //跳躍功能
            Slide();       //滑行功能
        }

        ChangeLine();  //切換跑道功能
        wasGround = isGround;
    }

    // void FixedUpdate()
    // {
    //     rb.position=new Vector3(rb.position.x,rb.position.y,startPos.z);
    // }
    void ChangeLine()
    {
        //換成第幾個Line
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (lineNum > 0)
            {
                lineNum--;
                targetPos.x += -lineDirection;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (lineNum < maxLineNum - 1)
            {
                lineNum++;
                targetPos.x += lineDirection;
            }
        }
        //移動位置  
        if (targetPos.x != rb.position.x)
        {
            targetPos = new Vector3(targetPos.x, transform.position.y, transform.position.z); //Y跟Z軸保持當前的值，而x軸則會使用上面修改的數值
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 10 * Time.deltaTime);
        }
    }
    void Jump()
    {
        if (!isJump)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isJump = true;
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                anim.SetBool("Jump", true);
            }
        }
        else if (isJump && !wasGround)
        {
            anim.SetBool("Jump", false);
            isJump = false;
        }
    }
    void Slide()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!isSlide)
            {
                anim.SetTrigger("Slide");
                isSlide = true;
                capsuleCollider.center = slideCenter;
                capsuleCollider.height = slideHight;
                Debug.Log("滑行");
            }
        }

        if (isSlide)
        {
            slideTime += Time.deltaTime;
            if (slideTime >= 1f)
            {
                isSlide = false;
                capsuleCollider.center = defaultCenter;
                capsuleCollider.height = defaultHight;
                slideTime = 0;
            }
        }
    }

    bool CheckGround() //檢查是否碰到地面
    {
        Collider[] collider = Physics.OverlapSphere(transform.position + checkOffset, 0.2f, ground);
        if (collider.Length != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + checkOffset, 0.2f);
    }
}
