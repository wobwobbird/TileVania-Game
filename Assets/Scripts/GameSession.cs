using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    int levelNumber;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    String LevelTextbefore;
    [SerializeField] TextMeshProUGUI LevelText;

    [SerializeField] TextMeshProUGUI gameOverScoreText;

    void Awake()
    {
        int numGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }   
    }

    void Start()
    {
        livesText.text = playerLives.ToString();

        int levelNumber = 1 + (SceneManager.GetActiveScene().buildIndex);
        Debug.Log(levelNumber);
    }

    void Update()
    {
        LevelTextbefore = levelNumber.ToString(); 
        LevelTextbefore = "L  " + LevelTextbefore;

        LevelText.text = LevelTextbefore;
    }

    public void AddLevelNumber()
    {
        levelNumber += 1;
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            SceneManager.LoadScene(7);
        }
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        FindAnyObjectByType<ScenePersist>().ResetScenePessist();
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    public TextMeshProUGUI GetScoreText()
    {
        return scoreText;
    }

    
}
