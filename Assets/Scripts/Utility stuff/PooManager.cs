using UnityEngine;
using System.Collections.Generic;

public class PooManager : MonoBehaviour
{
    public static PooManager Instance { get; private set; }

    public GameObject poolPrefab;
    public  int poolSize = 67;

    private List<GameObject> poolObjets = new List<GameObject>();

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            // destroy if theres multiple instance of gamemanagers
            Destroy(gameObject);
            return;
        }

        // this object is the Instance now
        Instance = this;

        DontDestroyOnLoad(gameObject); // THE CLASSIC
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            SpawnObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        GameObject obj = Instantiate(poolPrefab, transform);

        obj.SetActive(false);

        poolObjets.Add(obj);
    }

    // check if object is not ative, then set pos and rot, activate it.
    // //and return that obj
    public GameObject GetPoolObject(Vector3 pos, Quaternion rot)
    {
        // find it in the list
        foreach (GameObject obj in poolObjets)
        {
            if (!obj.activeSelf)
            {
                obj.transform.position = pos;
                obj.transform.rotation = rot;
                obj.SetActive(true);

                return obj;
            }
        }

        // if more object neeeded
        SpawnObject();

        // grab last object in list and active it (sae as abovoe) because ist the one juts spawned
        GameObject newObj = poolObjets[poolObjets.Count - 1];

        newObj.transform.position = pos;
        newObj.transform.rotation = rot;

        newObj.SetActive(true);

        return newObj;
    }

    public void DespawnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
