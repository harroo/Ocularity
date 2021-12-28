
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
            onEndAdjust = (float value) => {

                Debug.Log(value);
            } },

        },
    };

    private void Start () {

        Ocularity.ShowMenu(title);
    }
}
