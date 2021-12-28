
using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class OcularitySlider : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    public Sprite backgroundImage, idleImage, highlightedImage, clickedImage;
    public Color backgroundColor, idleColor, highlightedColor, clickedColor;

    public Action onAdjustMethod, onEndAdjustMethod;

    public float minValue, maxValue;
    public float value;

    private Image sliderImage;
    private bool highlighted;

    private GameObject sliderNotch;
    private Image sliderNotchImage;
    private float rectX;

    public void Setup (Vector2 notchScale) {

        sliderImage = GetComponent<Image>();
        sliderImage.sprite = backgroundImage;
        sliderImage.color = backgroundColor;

        sliderNotch = new GameObject("Notch");
        sliderNotch.transform.SetParent(transform);
        sliderNotch.transform.localScale = new Vector3(1, 1, 1);
        sliderNotchImage = sliderNotch.AddComponent<Image>();
        sliderNotchImage.raycastTarget = false;
        sliderNotch.GetComponent<RectTransform>().sizeDelta = notchScale;
        sliderNotch.transform.SetAsFirstSibling();
    }

    private void Update () {

        if (!highlighted) return;

        if (Input.GetMouseButtonDown(0)) {

            sliderNotchImage.sprite = clickedImage;
            sliderNotchImage.color = clickedColor;

            rectX = GetComponent<RectTransform>().rect.x * 1.8f;
        }

        if (Input.GetMouseButton(0)) {

            Vector2 localPos;
            RectTransform rectTransform = GetComponent<RectTransform>();
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, null, out localPos))
                return;

            int xpos = (int)(localPos.x);

            if (xpos < 0) xpos = xpos + (int)rectTransform.rect.width / 2;
            else xpos += (int)rectTransform.rect.width / 2;

            float xposf = (float)xpos / (rectTransform.rect.width - 1);
            xpos = (int)(xposf * maxValue);

            value = xpos;

            xposf -= 0.5f;
            sliderNotch.transform.position = new Vector3(transform.position.x + -xposf * rectX, transform.position.y, transform.position.z);

            if (onEndAdjustMethod != null) onAdjustMethod();
        }

        if (Input.GetMouseButtonUp(0)) {

            if (highlighted) {

                sliderNotchImage.sprite = highlightedImage;
                sliderNotchImage.color = highlightedColor;

            } else {

                sliderNotchImage.sprite = idleImage;
                sliderNotchImage.color = idleColor;
            }

            if (onEndAdjustMethod != null) onEndAdjustMethod();
        }
    }

    public void OnPointerClick (PointerEventData e) { }

    public void OnPointerEnter (PointerEventData e) {

        sliderNotchImage.sprite = highlightedImage;
        sliderNotchImage.color = highlightedColor;
        highlighted = true;
    }

    public void OnPointerExit (PointerEventData e) {

        sliderNotchImage.sprite = idleImage;
        sliderNotchImage.color = idleColor;
        highlighted = false;
    }
}