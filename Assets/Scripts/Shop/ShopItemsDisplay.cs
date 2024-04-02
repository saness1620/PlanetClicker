using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemsDisplay : MonoBehaviour
{
    [SerializeField] private ShopItemData[] _shopItemsData;
    [SerializeField] private ShopItemDisplay _shopItemDisplayPrefab;
    [SerializeField] private ContentSizeFitter _container;

    private void Awake()
    {
        foreach (var data in _shopItemsData)
        {
            var item = Instantiate(_shopItemDisplayPrefab, _container.transform);
            item.Init(data);
        }
    }
}
