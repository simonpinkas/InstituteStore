using UnityEngine;
using System.Collections;

public class ControllerEventsListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
     
        //Setup controller event listeners
        GetComponent<VRTK_ControllerEvents>().TriggerClicked += DoTriggerClicked;
        GetComponent<VRTK_ControllerEvents>().TriggerUnclicked += DoTriggerUnclicked;

        GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += DoTriggerAxisChanged;

        GetComponent<VRTK_ControllerEvents>().ApplicationMenuClicked += DoApplicationMenuClicked;
        GetComponent<VRTK_ControllerEvents>().ApplicationMenuUnclicked += DoApplicationMenuUnclicked;

        GetComponent<VRTK_ControllerEvents>().GripClicked += DoGripClicked;
        GetComponent<VRTK_ControllerEvents>().GripUnclicked += DoGripUnclicked;

        GetComponent<VRTK_ControllerEvents>().TouchpadClicked += DoTouchpadClicked;
        GetComponent<VRTK_ControllerEvents>().TouchpadUnclicked += DoTouchpadUnclicked;

        GetComponent<VRTK_ControllerEvents>().TouchpadTouched += DoTouchpadTouched;
        GetComponent<VRTK_ControllerEvents>().TouchpadUntouched += DoTouchpadUntouched;

        GetComponent<VRTK_ControllerEvents>().TouchpadAxisChanged += DoTouchpadAxisChanged;
    }

    void DebugLogger(uint index, string button, string action, float buttonPressure, Vector2 touchpadAxis)
    {
        Debug.Log("Controller on index '" + index + "' " + button + " has been " + action + " with a pressure of " + buttonPressure + " / trackpad axis at: " + touchpadAxis);
    }

    void DoTriggerClicked(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "TRIGGER", "pressed down", e.buttonPressure, e.touchpadAxis);
    }

    void DoTriggerUnclicked(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "TRIGGER", "released", e.buttonPressure, e.touchpadAxis);
    }

    void DoTriggerAxisChanged(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "TRIGGER", "axis changed", e.buttonPressure, e.touchpadAxis);
    }

    void DoApplicationMenuClicked(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "APPLICATION MENU", "pressed down", e.buttonPressure, e.touchpadAxis);
    }

    void DoApplicationMenuUnclicked(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "APPLICATION MENU", "released", e.buttonPressure, e.touchpadAxis);
    }

    void DoGripClicked(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "GRIP", "pressed down", e.buttonPressure, e.touchpadAxis);
    }

    void DoGripUnclicked(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "GRIP", "released", e.buttonPressure, e.touchpadAxis);
    }

    void DoTouchpadClicked(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "TOUCHPAD", "pressed down", e.buttonPressure, e.touchpadAxis);
    }

    void DoTouchpadUnclicked(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "TOUCHPAD", "released", e.buttonPressure, e.touchpadAxis);
    }

    void DoTouchpadTouched(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "TOUCHPAD", "touched", e.buttonPressure, e.touchpadAxis);
    }

    void DoTouchpadUntouched(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "TOUCHPAD", "untouched", e.buttonPressure, e.touchpadAxis);
    }

    void DoTouchpadAxisChanged(object sender, ControllerClickedEventArgs e)
    {
        DebugLogger(e.controllerIndex, "TOUCHPAD", "axis changed", e.buttonPressure, e.touchpadAxis);
    }
}
