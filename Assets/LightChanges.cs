using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class LightChanges : MonoBehaviour
{
    // create camera list that can be updated in the inspector
    public List<Camera> Cameras;

    // private bool on = false;
    public Light myLight;
    // create frame and button variables 
    private VisualElement frame;
    private Button button;
    private Button button1;

    // initialize click count
    int click = 0;
    int click2 = 0;

    // This function is called when the object becomes enabled and active.
    void OnEnable() {
        // get the UIDocument component (make sure this name matches!)
        var uiDocument = GetComponent<UIDocument>();
        // get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");
        // get the button, which is nested in the frame
        button = frame.Q<Button>("Button");
        // create event listener that calls ChangeCamera() when pressed
        button.RegisterCallback<ClickEvent>(ev => ChangeLight());

        button1 = frame.Q<Button>("Button1");
        // create event listener that calls ChangeCamera() when pressed
        button1.RegisterCallback<ClickEvent>(ev => ChangeCamera());
    }
   
    private void ChangeLight(){
        if (click == 0) {
            myLight.intensity = 0;
        } else if (click == 1) {
            myLight.intensity = 5;
        } else if (click == 2) {
            myLight.intensity = 10;
        }
        click++;
        if(click > 2){
            click = 0;
        }
    }

    private void ChangeCamera(){
        EnableCamera(click2);
        click2++;
        // reset counter so it is not out of bounds (only have 4 cameras)
        if(click2 > 1){
            click2 = 0;
        }
    }
    private void EnableCamera(int n)
    {
        // disable each of the cameras
        Cameras.ForEach(cam => cam.enabled = false);
        // Cameras.ForEach(cam => cam.depth = 0);
        // enable the selected camera
        Cameras[n].enabled = true;
        // Cameras[n].depth = 1;
    }
}
