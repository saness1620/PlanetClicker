using System.Collections;
using UnityEngine;

public class FloatTextGenerator : ObjectPool<FloatText>
{
    [SerializeField] private FloatText _floatTextPrefab;
    [SerializeField] private Vector2 _leftBottomPoint = new Vector2(-315, 90);
    [SerializeField] private Vector2 _rightTopPoint = new Vector2(315, 250);
    [SerializeField] private float _fadeOutSpeed = 1;
    [SerializeField] private float _flyingSpeed = 10;

    private void Awake()
    {
        InitPool(_floatTextPrefab);
    }

    private void OnEnable()
    {
        MoneyEarnButtonClickHandler.Clicked += OnMoneyEarnButtonClickHandlerClicked;
    }

    private void OnDisable()
    {
        MoneyEarnButtonClickHandler.Clicked -= OnMoneyEarnButtonClickHandlerClicked;
    }

    private void OnMoneyEarnButtonClickHandlerClicked()
    {
        var item = GetItem();
        item.Init(transform, SetRandomPositionInArea(), _fadeOutSpeed, _flyingSpeed, SetText());
    }

    private string SetText()
    {
        return "+" + MoneyConverter.ConvertToText(MoneyManager.Instance.MoneyPerClick);
    }

    private Vector2 SetRandomPositionInArea()
    {
        float randomX = Random.Range(_leftBottomPoint.x, _rightTopPoint.x);
        float randomY = Random.Range(_leftBottomPoint.y, _rightTopPoint.y);

        return new Vector2(randomX, randomY);
    }
}
