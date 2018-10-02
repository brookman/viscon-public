using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public void StartGame()
    {
        TimeProvider.SetOverrideTimeEnabled(true);
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        TimeProvider.SetOverrideTimeEnabled(false);
        SceneManager.LoadScene("Main");
    }
}