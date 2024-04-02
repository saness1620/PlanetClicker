using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentOpennedMenuDeactivator : MonoBehaviour
{
    [SerializeField] private MenuDisplay _currentOpennedMenu;

    private void OnEnable()
    {
        OpenMenuButtonClickHandler.Clicked += OnOpenMenuButtonClicked;
    }

    private void OnDisable()
    {
        OpenMenuButtonClickHandler.Clicked -= OnOpenMenuButtonClicked;
    }

    private void OnOpenMenuButtonClicked(MenuDisplay openningMenu)
    {
        if (_currentOpennedMenu == openningMenu)
            return;

        _currentOpennedMenu.gameObject.SetActive(false);
        _currentOpennedMenu = openningMenu;
    }
}
