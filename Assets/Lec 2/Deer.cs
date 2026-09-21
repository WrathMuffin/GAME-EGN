using UnityEngine;

public class Deer : Obstacle
{
    protected override void Start()
    {
        base.Start();

        speed = Random.Range(5f, 10f);
    }

    public override float GetSpawnRate()
    {
        return Random.Range(3f, 5f); ;
    }

    protected override void Behaviour()
    {
        base.Behaviour();
        Debug.Log("Oh deer!");

        // stay at the spot and falls over
        speed = 0f;
        transform.Rotate(0, 0, 90f);
    }
}