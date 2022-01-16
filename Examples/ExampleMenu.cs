
using UnityEngine;

public class ExampleMenu : MonoBehaviour {

    static OcularMenu title = new OcularMenu() {

        gridSize = new Vector2(300, 300),

        buttons = {

            new OcularButton() { title = "Play",
            onClick = () => {

                Debug.Log("Play!");
            } },

            new OcularButton() { title = "Settings",
            onClick = () => {

                Ocularity.ShowMenu(settings);
            } }
        },
    };

    static OcularMenu settings = new OcularMenu() {

        gridSize = new Vector2(600, 300),

        buttons = {

            new OcularButton() { title = "Set",
            onClick = () => {

                Debug.Log("Setted!");
            } },

            new OcularButton() { title = "Back",
            onClick = () => {

                Ocularity.ShowMenu(title);
            } }
        },

        sliders = {

            new OcularSlider() { title = "Slider",
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

            new OcularToggle() { title = "Toggle",
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
