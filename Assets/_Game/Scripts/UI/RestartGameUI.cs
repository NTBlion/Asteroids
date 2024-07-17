using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
    public class RestartGame : MonoBehaviour
    {
        [SerializeField] private Button _restartSceneButton;

        private void OnEnable()
        {
            _restartSceneButton.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _restartSceneButton.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            SceneManager.LoadScene(0);
        }
    }
}