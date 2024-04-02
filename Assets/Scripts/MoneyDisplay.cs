using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        MoneyManager.MoneyChanged += MoneyChanged;
    }

    private void OnDisable()
    {
        MoneyManager.MoneyChanged -= MoneyChanged;
    }

    private void MoneyChanged(int amount)
    {
        _text.text = MoneyConverter.ConvertToText(amount); 
    }
}
