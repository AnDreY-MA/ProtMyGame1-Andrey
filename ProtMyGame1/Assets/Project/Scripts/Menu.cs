using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayerHandler()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitHandler()
    {
        Application.Quit();
    }
}