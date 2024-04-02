using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemDisplay : ButtonClickHandler
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _image;

    private ShopItemData _data;

    public void Init(ShopItemData data)
    {
        _data = data;

        _title.text = data.Title;
        _description.text = data.Description;
        _cost.text = data.Cost.ToString();
        _icon.sprite = data.Icon;
    }

    private void TryBuy()
    {
        if (MoneyManager.Instance.Money < _data.Cost)
        {
            AudioManager.Instance.PlayLockOfMoneySound();
            ConfirmModalWindow.Instance.Show("недостаточно средств");
            return;
        }
            
        MoneyManager.Instance.BuyUpgrade(_data);
        Button.interactable = false;
        _cost.text = "куплено";
        _cost.color = new Color(255, 0, 0);
        _image.color = new Color(255, 0, 0);

    }

    protected override void OnButtonClicked()
    {
        ConfirmModalWindow.Instance.Show($"вы действительно хотите приобрести {_title.text} за {_cost.text}?", TryBuy, true);
    }
}
