using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    private const int UILayerID = 5;
    // сделать VFX в месте клика

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckButtonClicked();
        }
    }

    private static void CheckButtonClicked()
    {
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        if (results.Where(r => r.gameObject.layer == UILayerID && r.gameObject.TryGetComponent(out Button button)).Count() > 0)
        {
            AudioManager.Instance.PlayButtonClickSound();
        }
    }
}