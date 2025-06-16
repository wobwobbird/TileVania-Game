using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 10;

    private PlayerMovement pM;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        Debug.Log("NEXT LVELLL");
        FindAnyObjectByType<PlayerMovement>().DisablePlayer();
        FindFirstObjectByType<Sounds>().LevelCompleteMethod();
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        FindAnyObjectByType<GameSession>().AddLevelNumber();
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindAnyObjectByType<ScenePersist>().ResetScenePessist();
        SceneManager.LoadScene(nextSceneIndex);

    }
}
