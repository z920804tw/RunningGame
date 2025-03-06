using System.Reflection;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("物件設定")]
    public CapsuleCollider capsuleCollider;
    public Animator anim;
    Rigidbody rb;

    [Header("參數設定")]

    public float moveSpeed;
    public float jumpForce;
    [SerializeField] LayerMask ground;

    [SerializeField] bool isJump;
    [SerializeField] bool isGround;

    float slideTime;
    [SerializeField] bool isSlide;

    bool wasGround;

    [Header("跑道參數設定")]
    public float lineDirection;
    [SerializeField] int maxLineNum;
    [SerializeField] int lineNum;

    Vector3 targetPos;
    Vector3 startPos;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
    }

    // Update is called once per frame
    void Update()
    {
        isGround = CheckGround();
        transform.position=new Vector3(transform.position.x,transform.position.y,startPos.z);
        Jump();        //跳躍功能
        Slide();       //滑行功能
        ChangeLine();  //切換跑道功能
    }
    void FixedUpdate()
    {
        Vector3 forwardDir = transform.forward * moveSpeed;
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardDir.z);

        LimitSpeed();
    }
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
        if (targetPos.x != transform.position.x)
        {
            targetPos = new Vector3(targetPos.x, transform.position.y, transform.position.z); //Y跟Z軸保持當前的值，而x軸則會使用上面修改的數值
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 10 * Time.deltaTime);
        }
    }

    void LimitSpeed()
    {
        Vector3 flatVal = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVal.magnitude > moveSpeed)
        {
            Vector3 limitVal = flatVal.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVal.x, rb.velocity.y, limitVal.z);
        }
    }
    bool CheckGround() //檢查是否碰到地面
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, 0.2f, ground);
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
        if (isSlide) return;

        if (!isJump)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                anim.SetBool("Jump", true);
                isJump = true;
                Debug.Log("跳躍");
            }
        }
        else if (isJump)
        {
            if (isGround && !wasGround)
            {
                anim.SetBool("Jump", false);
                Debug.Log("碰到地面");
                isJump = false;
            }
        }
        wasGround = isGround;
    }
    void Slide()
    {
        if (isJump) return; //跳躍時無法滑行

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!isSlide)
            {
                anim.SetTrigger("Slide");
                isSlide = true;
                capsuleCollider.center = new Vector3(0, 0.32f, 0);
                capsuleCollider.height = 0.65f;
                Debug.Log("滑行");
            }
        }

        if (isSlide)
        {
            slideTime += Time.deltaTime;
            if (slideTime >= 1f)
            {
                isSlide = false;
                capsuleCollider.center = new Vector3(0, 0.85f, 0);
                capsuleCollider.height = 1.8f;
                slideTime = 0;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.2f);
    }
}
