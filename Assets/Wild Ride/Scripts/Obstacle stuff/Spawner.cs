using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Obstacle obstacle;

    private float timer;
    private float duration;

    private void Start()
    {
        duration = obstacle.GetSpawnRate();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            Instantiate(obstacle, transform.position, transform.rotation);

            timer = 0f;
            
            duration = obstacle.GetSpawnRate();
        }
    }
}
