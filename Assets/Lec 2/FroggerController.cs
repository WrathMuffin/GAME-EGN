using UnityEngine;
using UnityEngine.Rendering;

public class FroggerController : MonoBehaviour
{
    public float leapDist = 1.0f;
    public float leapSmoothness = 10.0f;

    public float leapSpeed = 1.0f;

    public float leapForce = 1.0f;

    private Vector3 leapStart;
    private Vector3 leapFinal;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            leapFinal = Leap(Vector3.forward);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            leapFinal = Leap(Vector3.back);
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            leapFinal = Leap(Vector3.left);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            leapFinal = Leap(Vector3.right);
        }

        rb.MovePosition(Vector3.Lerp(transform.position, leapFinal, leapSmoothness * Time.deltaTime));
    }

    public Vector3 Leap(Vector3 direction)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + direction.normalized * leapDist;

        rb.AddForce(Vector3.up * leapForce, ForceMode.Impulse);

        //Vector3.Lerp(startPos, endPos, leapSmoothness);
        return endPos;
    }
}
