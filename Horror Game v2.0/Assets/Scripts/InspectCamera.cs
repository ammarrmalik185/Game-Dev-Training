using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class InspectCamera : MonoBehaviour {
    
    public GameObject fpsCamera;

    private GameObject InspectElement;
    // private bool isActive;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            leaveInspect();
        }

        handleRotation();
    }

    public void goToInspect(GameObject inspectElement_) {
        InspectElement = inspectElement_;
        gameObject.SetActive(true);
        var transform1 = transform;
        transform1.position = fpsCamera.transform.position;
        transform1.rotation = fpsCamera.transform.rotation;
        InspectElement.transform.position = transform1.position + (transform1.forward.normalized);
        // InspectElement.GetComponent<Rigidbody>().useGravity = false;
        fpsCamera.SetActive(false);
    }
    
    void leaveInspect() {
        // InspectElement.GetComponent<Rigidbody>().useGravity = false;
        fpsCamera.SetActive(true);
        gameObject.SetActive(false);
    }

    void handleRotation() {
        if (Input.GetMouseButton(0)) {
            if(Input.GetAxis("Mouse Y")<0){
                InspectElement.transform.Rotate(new Vector3(-100f * Time.deltaTime, 0, 0));
            }
            if(Input.GetAxis("Mouse Y")>0){
                InspectElement.transform.Rotate(new Vector3(100f * Time.deltaTime, 0, 0));
            }
            if(Input.GetAxis("Mouse X")<0){
                InspectElement.transform.Rotate(new Vector3(0, 100f * Time.deltaTime, 0));
            }
            if(Input.GetAxis("Mouse X")>0){
                InspectElement.transform.Rotate(new Vector3(0, -100f * Time.deltaTime, 0));
            }
        }
    }
}
