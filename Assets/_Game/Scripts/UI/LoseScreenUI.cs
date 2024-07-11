using System;
using TMPro;
using UnityEngine;

public class LoseScreenUI : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _text.text = "Score: " + _scoreView.Text.text;
    }
}
