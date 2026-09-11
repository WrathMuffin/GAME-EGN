using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f, jumpPow = 10f, gravity = -10f;


    private CharacterController charCon;
    private Vector3 playerVel;
    private bool isGrounded;
    //private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        isGrounded = charCon.isGrounded;

        if (isGrounded && playerVel.y < 0)
        {
            playerVel.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVel.y += Mathf.Sqrt(jumpPow * -3.0f * gravity);
        }

        playerVel.y += gravity * Time.deltaTime;
        Vector3 move = transform.right * x + transform.forward * y;
        charCon.Move(move * speed * Time.deltaTime);
        charCon.Move(playerVel * Time.deltaTime);

    }
}
