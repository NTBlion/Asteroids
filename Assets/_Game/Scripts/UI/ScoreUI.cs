using _Game.Scripts.Scores;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private Score _score;

        [Inject]
        private void Construct(Score score)
        {
            _score = score;
        }

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