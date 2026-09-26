using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Cinemachine.IInputAxisOwner.AxisDescriptor;

public class Obstacle : MonoBehaviour
{
    protected float speed;

    // private Vector3 dir;

    protected virtual void Start()
    {
        speed = 1.0f;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 10f);
    }

    protected virtual void Behaviour()
    {
        speed *= 2;

        Debug.Log("Ouchie!");
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FroggerController player = other.GetComponent<FroggerController>();

            if (player != null)
            {
                player.Hit();
            }

            Behaviour();
        }
    }

    public virtual float GetSpawnRate()
    {
        return 1f;
    }
}
