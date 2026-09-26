using UnityEngine;

public class Sandwich : Food
{
    protected override void Start()
    {
        base.Start();
        //bonusScore = 50;
        //despawnTime = 10.0f;

        Debug.Log("Whose sandwich is this");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Animals"))
        {
            Debug.Log("Mlem, the food is eaten by someone, gl next time!");
            Destroy(gameObject);
        }
    }
}