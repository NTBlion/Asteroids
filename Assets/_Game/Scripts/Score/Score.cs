using System;
using UnityEngine;

namespace _Game.Scripts.Score
{
    public class Score : MonoBehaviour
    {
        private int _startScore = 0;

        public Action<int> ScoreAdded;
    
        public void AddScore()
        {
            _startScore++;
            ScoreAdded?.Invoke(_startScore);
        }
    }
}
