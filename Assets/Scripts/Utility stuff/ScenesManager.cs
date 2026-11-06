using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // readable for evryone (get) but settable is private (private set)
    public static ScenesManager Instance { get; private set; }

    private float currentTime;
   // private bool isGameWin = false;
    //private bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentTime = 0;

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

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    public void ShowTimeElapsed()
    {
        currentTime += Time.deltaTime;
        Debug.Log("Time elapsed: " + currentTime.ToString("F2"));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        currentTime = 0;
    }
}
