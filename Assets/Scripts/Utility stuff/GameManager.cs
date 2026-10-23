using System.Xml.Schema;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // readable for evryone (get) but settable is private (private set)
    public static GameManager Instance { get; private set; }

    private int totalScore = 0;

    private bool isGameWin = false;
    private bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
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

    public void AddScore(int score)
    {
        totalScore += score;
        Debug.Log("Current score: " + totalScore);
    }

    public void WinGame()
    {
        if (isGameWin || isGameOver)
        {
            return;
        }

        isGameWin = true;

        Debug.Log("Time to camp!");
    }

    public void GameOver()
    {
        if (isGameWin || isGameOver)
        {
            return;
        }

        isGameOver = true;

        Debug.Log("The wildlife deos get a little quirky at night...");
    }

    public bool IsGameWin()
    {
        return isGameWin;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
}
