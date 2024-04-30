using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlanetModalWindow : MonoBehaviour
{
    [SerializeField] private CurrentPlanetView _currentPlanetView;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text _header;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _blurPanel;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Button _closeButton;

    private PlanetButton _lastClickedPlanetButton;

    private void OnEnable()
    {
        PlanetButton.PlanetButtonClicked += OnPlanetButtonClicked;
        _buyButton.onClick.AddListener(OnBuyButtonClicked);
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnDisable()
    {
        PlanetButton.PlanetButtonClicked -= OnPlanetButtonClicked;
        _buyButton.onClick.RemoveListener(OnBuyButtonClicked);
        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
    }

    private void OnBuyButtonClicked()
    {
        ConfirmModalWindow.Instance.Show($"вы действительно хотите приобрести планету за {_costText.text}?", TryBuyPlanet, true);
    }

    private void OnCloseButtonClicked()
    {
        _blurPanel.gameObject.SetActive(false);
    }

    private void OnPlanetButtonClicked(PlanetButton planetButton)
    {
        if (planetButton.Bought == false)
        {
            ShowBuyModalWindow(planetButton);
        }
        else
        {
            ConfirmModalWindow.Instance.Show($"Перейти на {_lastClickedPlanetButton.Data.Name}?", SwitchCurrentPlanet, true);
        }
    }

    private void SwitchCurrentPlanet()
    {
        _currentPlanetView.SetNewActivePlanet(_lastClickedPlanetButton.Data);
    }

    private void ShowBuyModalWindow(PlanetButton planetButton)
    {
        _lastClickedPlanetButton = planetButton;

        _header.text = planetButton.Data.Name;
        _icon.sprite = planetButton.Data.Icon;
        _description.text = planetButton.Data.Description;
        _costText.text = planetButton.Data.Cost.ToString();

        _blurPanel.gameObject.SetActive(true);
    }

    private void TryBuyPlanet()
    {
        if (MoneyManager.Instance.Money < _lastClickedPlanetButton.Data.Cost)
        {
            AudioManager.Instance.PlayLockOfMoneySound();
            ConfirmModalWindow.Instance.Show("недостаточно средств");
            return;
        }

        _lastClickedPlanetButton.SetBuyState(true);
        _blurPanel.gameObject.SetActive(false);
        MoneyManager.Instance.BuyPlanet(_lastClickedPlanetButton.Data);
    }
}
