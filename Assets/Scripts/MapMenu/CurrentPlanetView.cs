using UnityEngine;
using UnityEngine.UI;

public class CurrentPlanetView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetNewActivePlanet(PlanetData data)
    {
        _image.sprite = data.Icon;
    }
}