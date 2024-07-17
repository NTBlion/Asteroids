using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
    public class RestartGame : MonoBehaviour
    {
        [SerializeField] private Button _restarSceneButton;

        private void OnEnable()
        {
            _restarSceneButton.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _restarSceneButton.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            SceneManager.LoadScene(0);
        }
    }
}
