using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.UI
{
    public class LoseScreenUI : MonoBehaviour
    {
        [FormerlySerializedAs("_scoreView")] [SerializeField] private ScoreUI scoreUI;
        [SerializeField] private TMP_Text _text;

        private void OnEnable()
        {
            _text.text = "Score: " + scoreUI.Text.text;
        }
    }
}
