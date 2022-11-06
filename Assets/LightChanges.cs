using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class LightChanges : MonoBehaviour
{
    // private bool on = false;
    public Light myLight;
    // create frame and button variables 
    private VisualElement frame;
    private Button button;
        // initialize click count
    int click = 0;
    // Start is called before the first frame update

    // void Start()
    // {
    //     myLight = GetComponent<Light>();

    // }

    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log("check1");
    //     if (Input.GetKeyDown(KeyCode.E)) {
    //         myLight.intensity = Mathf.PingPong(Time.time, 8);
    //     }
    //     // if (Input.GetKeyDown(KeyCode.E) && !on)
    //     // {
    //     //     Debug.Log("check2");
    //     //     myLight.SetActive(true);
    //     //     on = true;
    //     // }
    //     // else if (Input.GetKeyDown(KeyCode.E) && on)
    //     //     {
    //     //     Debug.Log("check3");
    //     //     myLight.SetActive(false);
    //     //     on = false;
    //     // }
    // }

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
        // myLight.intensity = Mathf.PingPong(Time.time, 8);
        // EnableCamera(click);
        // click++;
        // // reset counter so it is not out of bounds (only have 4 cameras)
        if(click > 2){
            click = 0;
        }
    }

    // public GameObject light;
    // private bool on = false;

    // // Use this for initialization
    // void OnTriggerStay(Collider plyr) {
    //     Debug.Log("check1");
    //     if (Input.GetKeyDown(KeyCode.E) && !on)
    //     {
    //         Debug.Log("check2");
    //         light.SetActive(true);
    //         on = true;
    //     }
    //     else if (Input.GetKeyDown(KeyCode.E) && on)
    //         {
    //         Debug.Log("check3");
    //         light.SetActive(false);
    //         on = false;
    //     }
    // }
}
