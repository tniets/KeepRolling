using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneButton : ButtonHandler
{
    [SerializeField] private string _sceneName;

    protected override void OnButtonClicked()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
