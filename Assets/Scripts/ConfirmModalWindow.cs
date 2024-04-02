using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ConfirmModalWindow : MonoBehaviour
{
    [SerializeField] private Image _blurPanel;
    [SerializeField] private TMP_Text _headerText;
    [SerializeField] private Button _acceptButton;
    [SerializeField] private Button _declineButton;

    public static ConfirmModalWindow Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        _acceptButton.onClick.AddListener(OnButtonClicked);
        _declineButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _acceptButton.onClick.RemoveListener(OnButtonClicked);
        _declineButton.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _acceptButton.onClick.RemoveAllListeners();
        _acceptButton.onClick.AddListener(OnButtonClicked);
        _declineButton.gameObject.SetActive(false);
        _blurPanel.gameObject.SetActive(false);
    }

    public void Show(string header, UnityAction action = null, bool isDeclineButtonEnabled = false)
    {
        _blurPanel.gameObject.SetActive(true);
        _headerText.text = header;

        if (isDeclineButtonEnabled)
            _declineButton.gameObject.SetActive(true);

        if (action != null)
            _acceptButton.onClick.AddListener(action);
    }
}