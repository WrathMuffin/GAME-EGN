using UnityEngine;

public class Lynx : Obstacle
{
    protected override void Start()
    {
        base.Start();

        speed = Random.Range(10f, 20f);
    }

    public override float GetSpawnRate()
    {
        return Random.Range(5f, 10f);
    }

    protected override void Behaviour()
    {
        base.Behaviour();
        Debug.Log("You hear a Lynx growled");
    }
}