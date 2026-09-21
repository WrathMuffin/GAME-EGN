using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class FroggerController : MonoBehaviour
{
    [SerializeField] protected int leapDist = 4;
    [SerializeField] protected float leapSpeed = 10.0f;
    [SerializeField] protected float hp = 10f;

    //private Animator anime;
    protected bool isLeaping = false;

    private BoxCollider boxCollider;
    private float currentHp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        //anime = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();

        currentHp = hp;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isLeaping)
        {
            return;
        }

        if (currentHp > 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryLeap(Vector3.forward);
                //anime.SetTrigger("Jump");
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                TryLeap(Vector3.left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                TryLeap(Vector3.right);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                TryLeap(Vector3.back);
            }
        }
    }

    protected virtual void Rotation(Vector3 dir)
    {
        transform.rotation = Quaternion.LookRotation(dir);
    }

    protected virtual bool TryLeap(Vector3 dir)
    {
        Rotation(dir);

        if (isBlocked(dir))
        {
            return false;
        }

        StartCoroutine(Leap(dir));
        return true;
    }

    protected IEnumerator Leap(Vector3 dir)
    {
        isLeaping = true;

        //Rotation(dir);

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + dir * leapDist;

        float t = 0.0f;

        while (t < 1.0f)
        {
            t += Time.deltaTime * leapSpeed;

            transform.position = Vector3.Lerp(startPos, endPos, t);

            yield return null;
        }

        transform.position = endPos;
        
        isLeaping = false;
    }

    protected virtual bool isBlocked(Vector3 dir)
    {
        Vector3 center = boxCollider.bounds.center;

        Vector3 half = boxCollider.bounds.extents;

        // make box from center forward to half leap
        RaycastHit[] hits = Physics.BoxCastAll(center, half, dir, transform.rotation, leapDist / 2.0f);

        foreach (RaycastHit h in hits)
        {
            if (h.collider.gameObject == gameObject)
            {
                // player GET STUCKKK OMGG
                continue;
            }

            if (h.collider.CompareTag("Animals"))
            {
                hp -= 1;

                // continue skips everything and go to next iteration of loo p
                continue;
            }

            return true;
        }

        return false;
    }
}
