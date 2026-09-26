using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FoodFactory : MonoBehaviour
{
    [SerializeField] private List<Food> foodPrefabs = new List<Food>();

    [SerializeField] private Vector2Int gridSize;
    [SerializeField] private GameObject planeToGrid;

    [SerializeField] private float spawnHeight = 5.0f;

    private float timer;
    [SerializeField] private float duration = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandomFood();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= duration)
        {
            SpawnRandomFood();
            timer = 0f;
        }
    }

    public void SpawnRandomFood()
    {
        Food randomType = foodPrefabs[Random.Range(0, foodPrefabs.Count)];

        Vector3 randomPos = GetRandomGridPos();

        Instantiate(randomType, randomPos, transform.rotation);
        //duration = randomType.GetDuration();

        //return duration;
    }

    private Vector3 GetRandomGridPos()
    {
        // grid postitons x and z
        int x = Random.Range(0, 4);
        int z = Random.Range(0, 4);

        // starts from road x and z, then moves to left side (half of size x) and moves forward (falf of size z)
        // this gives the top left position of the road
        // randomize position by multiplying random x and z to grid size (stil top left of the grid cell)
        // then adds half of the gridzise to get the center of the grid cell
        float xPos = planeToGrid.transform.position.x - (planeToGrid.transform.localScale.x / 2.0f) + (gridSize.x * x) + (gridSize.x / 2.0f);
        float zPos = planeToGrid.transform.position.z - (planeToGrid.transform.localScale.z / 2.0f) + (gridSize.y * z) + (gridSize.y);// / 2.0f); //im tired, i dont want to know why there is an offset here im going to not divide this one
    
        return new Vector3(xPos, planeToGrid.transform.position.y + spawnHeight, zPos);
    }
}
