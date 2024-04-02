using UnityEngine.Events;
public class MoneyEarnButtonClickHandler : ButtonClickHandler
{
    public static event UnityAction Clicked;

    protected override void OnButtonClicked()
    {
        Clicked?.Invoke();
    }
}
