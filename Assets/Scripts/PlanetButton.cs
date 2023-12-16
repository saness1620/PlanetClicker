using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlanetButton : MonoBehaviour
{
    [SerializeField] private Button _planetButton;

    public event UnityAction ButtonClicked;

    private void OnEnable()
    {
        _planetButton.onClick.AddListener(OnPlanetButtonClicked);
    }

    private void OnDisable()
    {
        _planetButton.onClick.AddListener(OnPlanetButtonClicked);
    }

    private void OnPlanetButtonClicked()
    {
        ButtonClicked?.Invoke();
    }
    // обработать нажатие кнопки, запустить событие об этом
}
