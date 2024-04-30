using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetButton : ButtonClickHandler
{
    [SerializeField] private PlanetData _data;

    public bool Bought { get; private set; } = false;
    public PlanetData Data => _data;

    public static Action<PlanetButton> PlanetButtonClicked;

    protected override void OnButtonClicked()
    {
        PlanetButtonClicked?.Invoke(this);
    }

    public void SetBuyState(bool state)
    {
        Bought = state;
    }
}
