using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("物件設定")]
    public BoxCollider boxCollider;
    public CapsuleCollider capsuleCollider;
    Rigidbody rb;

    [Header("參數設定")]

    public float forwardForce;
    public float moveSideForce;
    [SerializeField] int dirNum;
    Vector3 targetPos;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

        dirNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        SetSide();
    }
    void SetSide()
    {
        //
        if (Input.GetKeyDown(KeyCode.A))
        {
            dirNum--;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dirNum++;
        }
        dirNum = Mathf.Clamp(dirNum, 0, 2);


        //移動位置
        targetPos = transform.position;
        switch (dirNum)
        {
            case 0:
                targetPos.x = -moveSideForce; // 左邊
                break;
            case 1:
                targetPos.x = 0;
                break;
            case 2:
                targetPos.x = moveSideForce; // 右邊
                break;
        }
        if (targetPos.x != transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 10 * Time.deltaTime);
        }
    }


    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce, ForceMode.Force);
        LimitSpeed();

        // rb.AddForce(horizonInput*moveSideForce,0,0,ForceMode.Force);
    }
    void LimitSpeed()
    {
        Vector3 flatVal = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVal.magnitude > forwardForce)
        {
            Vector3 limitVal = flatVal.normalized * forwardForce;
            rb.velocity = new Vector3(limitVal.x, rb.velocity.y, limitVal.z);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("hit Obstacle");
            capsuleCollider.enabled = false;
            boxCollider.enabled = true;
            this.enabled = false;


        }
    }
}
