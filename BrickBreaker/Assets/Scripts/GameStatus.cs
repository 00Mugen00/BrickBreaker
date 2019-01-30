using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)]
    [SerializeField]
    float gameSpeed = 1f;
    [SerializeField]
    int pointsPerBrickDestroyed = 10;
    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            // Let's game status persist on the next level
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBrickDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
