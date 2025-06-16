using TMPro;
using UnityEngine;

public class MenuScore : MonoBehaviour
{
    public TextMeshProUGUI scoreTextRef;

    void Start()
    {
        GameSession gameSession = FindAnyObjectByType<GameSession>();

        if (gameSession != null)
        {
            scoreTextRef = gameSession.GetScoreText();
            Debug.Log("Score: " + scoreTextRef.text);
        }
    }

}

