
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class OcularityMenuConstructor : MonoBehaviour {

    public static OcularityMenuConstructor instance;

    private List<GameObject> cache = new List<GameObject>();
    private GridLayoutGroup layoutGroup;

    private void Awake () {

        instance = this;

        layoutGroup = gameObject.AddComponent<GridLayoutGroup>();
    }

    public void Construct (OcularMenu oMenu) {

        Clear();

        GetComponent<RectTransform>().sizeDelta = oMenu.gridSize;
        layoutGroup.cellSize = oMenu.cellSize;
        layoutGroup.spacing = oMenu.spacing;

        layoutGroup.childAlignment = oMenu.alignment;

        oMenu.buttons.ForEach(delegate(OcularButton oButton) {

            GameObject button = new GameObject(oButton.name);
            button.transform.SetParent(transform);
            button.transform.localScale = new Vector3(1, 1, 1);
            cache.Add(button);

            GameObject textObject = new GameObject(oButton.name + " Text");
            textObject.transform.SetParent(button.transform);
            textObject.transform.localScale = new Vector3(1, 1, 1);

            Text text = textObject.AddComponent<Text>();
            textObject.GetComponent<RectTransform>().sizeDelta = oMenu.cellSize;
            text.font = OcularityPrefix.instance.font;
            text.text = oButton.title;
            text.color = OcularityPrefix.instance.fontColor;
            text.alignment = TextAnchor.MiddleCenter;

            var behaviour = button.AddComponent<OcularityButton>();
            behaviour.idleImage = OcularityPrefix.instance._idleImage;
            behaviour.idleColor = OcularityPrefix.instance.idleColor;
            behaviour.highlightedImage = OcularityPrefix.instance._highlightedImage;
            behaviour.highlightedColor = OcularityPrefix.instance.highlightedColor;
            behaviour.clickedImage = OcularityPrefix.instance._clickedImage;
            behaviour.clickedColor = OcularityPrefix.instance.clickedColor;
            behaviour.onClickMethod = oButton.onClick;
        });
    }

    public void Clear () {

        cache.ForEach(delegate(GameObject go) {

            Destroy(go);
        });

        cache.Clear();
    }
}
