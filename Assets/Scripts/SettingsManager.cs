using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Toggle _enableSoundToggle;

    private void OnEnable()
    {
        _soundSlider.onValueChanged.AddListener(OnSoundSLiderValueChanged);
        _musicSlider.onValueChanged.AddListener(OnMusicSLiderValueChanged);
        _enableSoundToggle.onValueChanged.AddListener(OnSoundsToggleValueChanged);
    }

    private void OnDisable()
    {
        _soundSlider.onValueChanged.RemoveListener(OnSoundSLiderValueChanged);
        _musicSlider.onValueChanged.RemoveListener(OnMusicSLiderValueChanged);
        _enableSoundToggle.onValueChanged.RemoveListener(OnSoundsToggleValueChanged);
    }

    private void OnSoundSLiderValueChanged(float newValue)
    {
        AudioManager.Instance.SetSoundVolume(newValue);
    }

    private void OnMusicSLiderValueChanged(float newValue)
    {
        AudioManager.Instance.SetMusicVolume(newValue);
    }

    private void OnSoundsToggleValueChanged(bool newValue)
    {
        AudioManager.Instance.SwitchAudioEnabling(newValue);
    }
}