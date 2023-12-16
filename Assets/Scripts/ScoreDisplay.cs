using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _gameManager.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _gameManager.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int amount)
    {
        _text.text = amount.ToString();
    }
    // отреагировать на событие изменения счета и показать его в тексте
}
