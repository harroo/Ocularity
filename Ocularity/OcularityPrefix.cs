
using UnityEngine;
using UnityEngine.UI;

public class OcularityPrefix : MonoBehaviour {

    public static OcularityPrefix instance;
    private void Awake () { instance = this; }

    public Sprite backgroundImage;
    public Color backgroundColor = new Color(1, 1, 1, 1);

    [Space()]
    public Sprite idleImage;
    public Color idleColor = new Color(1, 1, 1, 1);

    [Space()]
    public Sprite highlightedImage;
    public Color highlightedColor = new Color(1, 1, 1, 1);

    [Space()]
    public Sprite clickedImage;
    public Color clickedColor = new Color(1, 1, 1, 1);

    [HideInInspector]
    public Sprite _idleImage => idleImage == null ? null : idleImage;
    public Sprite _highlightedImage => highlightedImage == null ? null : highlightedImage;
    public Sprite _clickedImage => clickedImage == null ? null : clickedImage;

    [Space()]
    public Font font;
    public Color fontColor = new Color(1, 1, 1, 1);
}
