using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    public float forwardForce;
    public float sideForce;
    float horizontalInput;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(rb.velocity.magnitude);

    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0,forwardForce, ForceMode.Force);
        
        LimitSpeed();

        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(horizontalInput * sideForce, 0, 0, ForceMode.Force);

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
            this.enabled = false;
        }
    }
}
