using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;

    private void OnEnable()
    {
        _soundSlider.onValueChanged.AddListener(OnSoundSLiderValueChanged);
    }

    private void OnDisable()
    {
        _soundSlider.onValueChanged.RemoveListener(OnSoundSLiderValueChanged);
    }

    private void OnSoundSLiderValueChanged(float newValue)
    {
        AudioManager.Instance.SetSoundVolume(newValue);
    }
}