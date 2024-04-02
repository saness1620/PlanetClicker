using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FloatText : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void Init(Transform newParent, Vector2 position, float fadeOutSpeed, float flyingSpeed, string text)
    {
        transform.parent = newParent;
        _text.rectTransform.anchoredPosition = position;
        _text.text = text;
        gameObject.SetActive(true);

        StartCoroutine(Animating(fadeOutSpeed, flyingSpeed));
    }

    private IEnumerator Animating(float fadeOutSpeed, float flyingSpeed)
    {
        float alpha = 1;

        while (alpha > 0)
        {
            var newColor = _text.color;
            newColor.a = alpha;
            _text.color = newColor;
            alpha -= Time.deltaTime * fadeOutSpeed;
            transform.Translate(Vector2.up * Time.deltaTime * flyingSpeed);

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
