using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float slowFactor = 10f;


    private int score = 0;


    // Singleton
    private static GameController instance;

    public static GameController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.SetText(score.ToString());
    }

    public void SlowOnCollision(int life)
    {
        StartCoroutine(SlowDownTime(life));
    }

    IEnumerator SlowDownTime(int life)
    {
        // Change time scale (slow down)
        Time.timeScale = 1f / slowFactor;
        Time.fixedDeltaTime /= slowFactor;

        // Wait 2 seconds before changing time back to normal
        // (Also divided by slow factor, to make it actual 2 sec after time slows down)
        yield return new WaitForSeconds(2f / slowFactor);
        
        // Revert time changes
        Time.timeScale = 1f;
        Time.fixedDeltaTime *= slowFactor;
        
        // Check if dead
        if (life == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // TODO Show "Game Over", Score, buttons for restart.
        // TODO Maybe some buttons for sharing on FB/Twitter
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}