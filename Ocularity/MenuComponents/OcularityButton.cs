
using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class OcularityButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    public Sprite idleImage, highlightedImage, clickedImage;
    public Color idleColor, highlightedColor, clickedColor;

    public Action onClickMethod;

    private Image buttonImage;
    private bool highlighted;

    private void Start () {

        buttonImage = GetComponent<Image>();
    }

    private void Update () {

        if (!highlighted) return;

        if (Input.GetMouseButtonDown(0)) {

            buttonImage.sprite = clickedImage;
            buttonImage.color = clickedColor;
        }

        if (Input.GetMouseButtonUp(0)) {

            if (highlighted) {

                buttonImage.sprite = highlightedImage;
                buttonImage.color = highlightedColor;

            } else {

                buttonImage.sprite = idleImage;
                buttonImage.color = idleColor;
            }

            if (onClickMethod != null) onClickMethod();
        }
    }

    public void OnPointerClick (PointerEventData e) { }

    public void OnPointerEnter (PointerEventData e) {

        buttonImage.sprite = highlightedImage;
        buttonImage.color = highlightedColor;
        highlighted = true;
    }

    public void OnPointerExit (PointerEventData e) {

        buttonImage.sprite = idleImage;
        buttonImage.color = idleColor;
        highlighted = false;
    }
}
