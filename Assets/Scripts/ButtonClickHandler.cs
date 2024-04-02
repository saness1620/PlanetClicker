using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonClickHandler : MonoBehaviour
{
    [SerializeField] protected Button Button;

    private void Awake()
    {
        if (TryGetComponent(out Button button))
            Button = button;
    }

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClicked);
    }

    protected abstract void OnButtonClicked();
}
