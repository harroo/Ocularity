
// Apply this to the usual sort of UnityEngine.Button and it shall become
// Like all others in your Ocularity Prefix.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OcularityButtonMimic : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    public Sprite idleImage, highlightedImage, clickedImage;
    public Color idleColor, highlightedColor, clickedColor;

    private Image buttonImage;
    private bool highlighted;

    private void Start () {

        idleImage = OcularityPrefix.instance._idleImage;
        idleColor = OcularityPrefix.instance.idleColor;
        highlightedImage = OcularityPrefix.instance._highlightedImage;
        highlightedColor = OcularityPrefix.instance.highlightedColor;
        clickedImage = OcularityPrefix.instance._clickedImage;
        clickedColor = OcularityPrefix.instance.clickedColor;

        GetComponentInChildren<Text>().color = OcularityPrefix.instance.fontColor;

        buttonImage = GetComponent<Image>();

        buttonImage.sprite = idleImage;
        buttonImage.color = idleColor;
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
        }
    }

    public void OnPointerClick (PointerEventData e) {

        // Uncomment these lines to enable sounds, Reverb is required.
        if (OcularityPrefix.instance.clickSound != "")
            ReverbAudioManager.Play(OcularityPrefix.instance.clickSound);
    }

    public void OnPointerEnter (PointerEventData e) {

        buttonImage.sprite = highlightedImage;
        buttonImage.color = highlightedColor;
        highlighted = true;

        // Uncomment these lines to enable sounds, Reverb is required.
        if (OcularityPrefix.instance.highlightSound != "")
            ReverbAudioManager.Play(OcularityPrefix.instance.highlightSound);
    }

    public void OnPointerExit (PointerEventData e) {

        buttonImage.sprite = idleImage;
        buttonImage.color = idleColor;
        highlighted = false;
    }
}
