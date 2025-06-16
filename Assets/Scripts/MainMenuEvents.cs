using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument document;
    private Button button;
    private Button button2;

    private void Awake()
    {
        document = GetComponent<UIDocument>();

        button = document.rootVisualElement.Q("StartGameElement") as Button;
        button2 = document.rootVisualElement.Q("Settings") as Button;
        button.RegisterCallback<ClickEvent>(OnPlayGameClick);
        button2.RegisterCallback<ClickEvent>(OnPlayGameClickSettings);
    }

    private void OnDsable()
    {
        button.UnregisterCallback<ClickEvent>(OnPlayGameClick);        
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("start click");
        SceneManager.LoadScene(0);
    }

    private void OnPlayGameClickSettings(ClickEvent evt)
    {
        Debug.Log("settings click");
        SceneManager.LoadScene(4);
    }




}
