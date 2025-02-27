using System.Reflection;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("物件設定")]
    public CapsuleCollider capsuleCollider;
    public Animator anim;
    Rigidbody rb;

    [Header("參數設定")]
    public int maxHp;
    [SerializeField]int currentHp;
    public float moveSpeed;
    public float jumpForce;


    [SerializeField] bool isJump;
    [SerializeField] bool isGround;
    bool wasJump;

    [Header("跑道參數設定")]
    public float lineDirection;
    [SerializeField] int maxLineNum;
    [SerializeField] int lineNum;

    Vector3 targetPos;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        lineNum = maxLineNum / 2;
        currentHp = maxHp;
        targetPos = new Vector3(0, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if(currentHp<=0) this.enabled=false;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        isGround = Physics.Raycast(transform.position, Vector3.down, 0.6f);
        Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red);
        //跳躍功能
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            Jump();
        }
        CheckLand();
        wasJump = isGround;

        //切換跑道功能
        ChangeLine();


    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, moveSpeed, ForceMode.Force);
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

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        anim.SetBool("Jump", true);
        isJump = true;
    }

    void CheckLand()
    {
        if (isJump && isGround)
        {
            if (!wasJump)
            {
                anim.SetBool("Jump", false);
                Debug.Log("觸發");
                isJump = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag("Obstacle"))

        // {
        //     Debug.Log("hit Obstacle");
        //     currentHp--;
        //     if (currentHp <= 0)
        //     {
        //         this.enabled = false;
        //     }

        // }
    }

    public int CurrentHp
    {
        get{return currentHp;}
        set {currentHp=value;}
    }

}
