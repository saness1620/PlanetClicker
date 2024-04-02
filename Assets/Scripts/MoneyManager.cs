using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }

    public int Money { get; private set; } = 0;
    public int MoneyPerTick { get; private set; } = 0;
    public int MoneyPerClick { get; private set; } = 1;

    private WaitForSeconds _incomeInterval;

    public static event UnityAction<int> MoneyChanged;

    private const int TickTime = 1;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        MoneyEarnButtonClickHandler.Clicked += OnMoneyEarnButtonClicked;
    }

    private void OnDisable()
    {
        MoneyEarnButtonClickHandler.Clicked -= OnMoneyEarnButtonClicked;
    }

    private void Start()
    {
        _incomeInterval = new WaitForSeconds(TickTime);
        StartCoroutine(AddMoneyPerSecond());
    }

    private void Update()
    {
        CheckCheatCodeButton();
    }

    private void CheckCheatCodeButton()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Money += 999;
            MoneyChanged?.Invoke(Money);
        }
    }

    private void OnMoneyEarnButtonClicked()
    {
        Money += MoneyPerClick;
        MoneyChanged?.Invoke(Money);
    }

    private IEnumerator AddMoneyPerSecond()
    {
        while (true)
        {
            Money += MoneyPerTick;
            MoneyChanged?.Invoke(Money);

            yield return _incomeInterval;
        }
    }

    public void BuyUpgrade(ShopItemData data)
    {
        Money -= data.Cost;
        MoneyChanged?.Invoke(Money);

        MoneyPerClick += data.BonusMoneyPerClick;
        MoneyPerTick += data.BonusMoneyPerTick;
    }
}