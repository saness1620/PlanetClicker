using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OpenMenuButtonClickHandler : ButtonClickHandler
{
    [SerializeField] private MenuDisplay _openningMenu;

    public static event UnityAction<MenuDisplay> Clicked;

    protected override void OnButtonClicked()
    {
        Clicked?.Invoke(_openningMenu);
        _openningMenu.gameObject.SetActive(true);
    }
}
