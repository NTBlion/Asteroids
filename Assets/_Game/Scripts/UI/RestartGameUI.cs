using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Scripts.UI
{
    public class RestartGame : MonoBehaviour
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
