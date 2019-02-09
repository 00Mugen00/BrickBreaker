using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Range(0.1f,10f)]
    [SerializeField]
    float gameSpeed = 1f;
    [SerializeField]
    int pointsPerBrickDestroyed = 10;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    bool isAutoPlayEnabled;

    [SerializeField]
    int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameManager>().Length;
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

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
