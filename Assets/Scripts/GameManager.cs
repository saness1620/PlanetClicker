using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlanetButton _planetButton;

    private int _score;

    public event UnityAction<int> ScoreChanged;

    private void OnEnable()
    {
        _planetButton.ButtonClicked += OnPlanetButtonClicked;
    }

    private void OnDisable()
    {
        _planetButton.ButtonClicked -= OnPlanetButtonClicked;
    }

    private void OnPlanetButtonClicked()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
    // отреагировать на событие нажатия кнопки и увеличить счет на 1, запустить об этом событие (что счент изменился)
}
