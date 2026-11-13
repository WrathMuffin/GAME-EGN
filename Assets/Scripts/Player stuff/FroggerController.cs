using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FroggerController : MonoBehaviour
{
    [SerializeField] protected int leapDist = 4;
    [SerializeField] protected float leapSpeed = 10.0f;
    [SerializeField] protected float hp = 10f;

    [SerializeField] protected GameObject bodyPrefab, newBody;

    [SerializeField] private LayerMask blockerLayer;

    //private Animator anime;
    protected bool isLeaping = false, isLeft = false, isRight = false;

    private float currentHp;

    private Transform currPos;
    private float rotAngle;

    private float timer;
    [SerializeField] private float duration = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        //anime = GetComponent<Animator>();
        currentHp = hp;
        currPos = transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer += Time.deltaTime;

        if (isLeaping)
        {
            return;
        }

        if (currentHp > -10)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                rotAngle += -90.0f;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                rotAngle += 90.0f;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                ScenesManager.Instance.RestartGame();
            }

            if (Input.GetKey(KeyCode.E))
            {
                ScenesManager.Instance.ShowTimeElapsed();
            }
        }



        if (timer >= duration)
        {
            transform.rotation = Quaternion.Euler(0, rotAngle, 0);
            transform.position += transform.forward * leapDist;

            if (transform != currPos)
            {
                newBody.transform.position = currPos.position;
                newBody.transform.rotation = currPos.rotation;
            }

            timer = 0f;
        }

        currPos = transform;
    }

    protected virtual void Rotation(Vector3 dir)
    {
        //  future lerp be here?
        transform.rotation = Quaternion.LookRotation(dir);
    }


    protected virtual bool TryLeap(Vector3 dir)
    {
        BoxCollider collider = GetComponent<BoxCollider>();

        Vector3 center = collider.bounds.center;
        Vector3 extents = collider.bounds.extents;

        if (Physics.BoxCast(center, extents, dir, out RaycastHit hit, transform.rotation, leapDist, blockerLayer))
        {
            // try leap is false because anything in the blocker layer is blocking the playeer
            return false;
        }

        Rotation(dir);
        StartCoroutine(Leap(dir));

        return true;
    }

    protected IEnumerator Leap(Vector3 dir)
    {
        isLeaping = true;

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

    public void Hit()
    {
        currentHp -= 1.0f;

        Debug.Log("Ouch! HP is now " + currentHp);

        if (currentHp <= 0.0f)
        {
            currentHp = 0.0f;
            Debug.Log("You dead");

            transform.localScale = new Vector3(1.0f, 0.1f, 1.0f);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animals"))
        {
            Hit();
        }

        if (other.CompareTag("Food"))
        {
            GrowBody();
        }
    }

    public void GrowBody()
    {
        newBody = Instantiate(bodyPrefab, currPos, currPos);
    }
}
