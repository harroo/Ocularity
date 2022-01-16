
using UnityEngine;

public class ExampleMenu : MonoBehaviour {

    static OcularMenu title = new OcularMenu() {

        gridSize = new Vector2(300, 300),

        buttons = {

            new OcularButton() { title = "Play", order = 1,
            onClick = () => {

                Debug.Log("Play!");
            } },

            new OcularButton() { title = "Settings", order = 2,
            onClick = () => {

                Ocularity.ShowMenu(settings);
            } }
        },
    };

    static OcularMenu settings = new OcularMenu() {

        gridSize = new Vector2(600, 300),

        buttons = {

            new OcularButton() { title = "Set", order = 1,
            onClick = () => {

                Debug.Log("Setted!");
            } },

            new OcularButton() { title = "Back", order = 4,
            onClick = () => {

                Ocularity.ShowMenu(title);
            } }
        },

        sliders = {

            new OcularSlider() { title = "Slider", order = 3,
            min = 0, max = 100,
            onLoad = (OcularitySlider slider) => {

                slider.value = 64;
            },
            onAdjust = (float value) => {

                Debug.Log("Adjusted: " + value);
            },
            onEndAdjust = (float value) => {

                Debug.Log(value);
            } },

        },

        toggles = {

            new OcularToggle() { title = "Toggle", order = 2,
            values = new string[] {
                "1", "2", "3"
            },
            onLoad = (OcularityToggle toggle) => {

                toggle.value = toggle.values[2];
            },
            onToggle = (string value) => {

                Debug.Log(value);
            } },

        },
    };

    private void Start () {

        Ocularity.ShowMenu(title);
    }
}
