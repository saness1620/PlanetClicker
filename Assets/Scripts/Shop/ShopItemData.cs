using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item Data", menuName = "Create New Shop Item Data", order = 54)]
public class ShopItemData : ScriptableObject
{
    [Header("UI Properties")]
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _icon;

    [Header("Logic Properties")]
    [SerializeField] private int _bonusMoneyPerTick;
    [SerializeField] private int _bonusMoneyPerClick;

    public string Title => _title;
    public string Description => _description;
    public int Cost => _cost;
    public Sprite Icon => _icon;
    public int BonusMoneyPerTick => _bonusMoneyPerTick;
    public int BonusMoneyPerClick => _bonusMoneyPerClick;
}
