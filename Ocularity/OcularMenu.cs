
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class OcularMenu {

    public string name = "oMenu";
    public string title;

    public List<OcularButton> buttons = new List<OcularButton>();

    public Vector2 gridSize = new Vector2(300, 300);
    public Vector2 cellSize = new Vector2(265, 64);
    public Vector2 spacing = new Vector2(6, 6);

    public TextAnchor alignment = TextAnchor.MiddleCenter;
}

[Serializable]
public class OcularButton {

    public string name = "oButton";
    public string title;

    public Action onClick;
}
