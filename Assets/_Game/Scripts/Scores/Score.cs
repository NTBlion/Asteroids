using System;
using UnityEngine;

namespace _Game.Scripts.Scores
{
    public class Score : MonoBehaviour
    {
        private int _startScore = 0;

        public event Action<int> ScoreAdded;

        public void AddScore()
        {
            _startScore++;
            ScoreAdded?.Invoke(_startScore);
        }
    }
}