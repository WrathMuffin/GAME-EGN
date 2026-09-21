using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Cinemachine.IInputAxisOwner.AxisDescriptor;

public class Obstacle : MonoBehaviour
{
    protected float speed;

    // private Vector3 dir;

    private BoxCollider boxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        //anime = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (isHitPlayer())
        {
            Behaviour();
        }

        Destroy(gameObject, 20f);
    }

    protected virtual void Behaviour()
    {
        speed = 0;
        Debug.Log("Obstacle hit!");
    }

    public virtual float GetSpawnRate()
    {
        return 1f;
    }

    protected virtual bool isHitPlayer()
    {
        Vector3 center = transform.TransformPoint(boxCollider.center);

        Vector3 half = Vector3.Scale(boxCollider.size, transform.lossyScale) / 2.0f;

        // overlap check if player is withing colldier bounds
        Collider[] hits = Physics.OverlapBox(center, half, transform.rotation);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                return true;
            }

        }

        return false;
    }
}
