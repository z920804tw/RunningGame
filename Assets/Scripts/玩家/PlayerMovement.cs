using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("物件設定")]
    public Animator anim;
    Rigidbody rb;
    CapsuleCollider capsuleCollider;

    [Header("蒐集碰撞設定")]
    public BoxCollider collectTrigger;
    [SerializeField] Vector3 colliderSize;

    [Header("跳躍參數設定")]
    public float jumpForce;
    [SerializeField] LayerMask ground;
    [SerializeField] float checkOffset;
    [SerializeField] bool isJump;
    [SerializeField] bool isGround;
    bool wasGround;
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
        transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z);

        isGround = Physics.Raycast(transform.position, transform.up * -1, checkOffset);
        Debug.DrawRay(transform.position, transform.up * -checkOffset, Color.red);

        if (isGround)
        {
            Jump();        //跳躍功能
            Slide();       //滑行功能
        }
        ChangeLine();  //切換跑道功能
        wasGround = isGround;


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
    void Jump()
    {
        if (!isJump)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                isJump = true;
                anim.SetBool("Jump", true);
                Debug.Log("Jump");
            }
        }
        else if (isJump && !wasGround)
        {
            isJump = false;
            anim.SetBool("Jump", false);
            Debug.Log("Ground");
        }
    }
    void Slide()
    {
        if (!isSlide)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                anim.SetTrigger("Slide");
                isSlide = true;
                capsuleCollider.center = slideCenter;
                capsuleCollider.height = slideHight;
                Debug.Log("滑行");

            }
        }
        else if (isSlide)
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

    public void ChangeCollectSize(float time,Vector3 size)
    {
        collectTrigger.size=size;
        StartCoroutine(CollectTime(time));
    }

    IEnumerator CollectTime(float time)
    {
        //時間到會回復大小(1,1,1)
        yield return new WaitForSeconds(time);
        collectTrigger.size=colliderSize;
    }

}
