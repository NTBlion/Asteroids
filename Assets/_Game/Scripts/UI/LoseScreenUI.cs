using TMPro;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public class LoseScreenUI : MonoBehaviour
    {
        [SerializeField] private ScoreUI scoreUI;
        [SerializeField] private TMP_Text _text;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _text.text = "Score: " + scoreUI.Text.text;
        }
    }
}