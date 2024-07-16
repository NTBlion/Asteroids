using _Game.Scripts.Scores;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Score _score;
        [SerializeField] private TMP_Text _text;

        public TMP_Text Text => _text;

        private void OnEnable()
        {
            _score.ScoreAdded += OnScoreAdded;
        }

        private void OnDisable()
        {
            _score.ScoreAdded -= OnScoreAdded;
        }

        private void OnScoreAdded(int score)
        {
            Text.text = score.ToString();
        }
    }
}