using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
