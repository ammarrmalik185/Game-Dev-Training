using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour {
    [SerializeField] private Image batteryBar;
    [SerializeField] private Light lightSource;
    [SerializeField] private float powerCurrent;
    [SerializeField] private float powerTotal;
    [SerializeField] private float intensityTotal;
    [SerializeField] private InspectCamera1 inspectCamera;
    void Update() {
        if (powerCurrent > 0) {
            powerCurrent -= 1 * Time.deltaTime;
        }
        float powerRatio = powerCurrent / powerTotal;
        batteryBar.fillAmount = powerRatio;
        lightSource.intensity = powerRatio * intensityTotal;
        lookingAt();
    }

    void inspect(GameObject inspectElement) {
        Debug.Log("hit torch");
        inspectCamera.goToInspect(inspectElement);
        
    }
    
    void lookingAt() {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f)) {

            GameObject hitComponent = hit.collider.gameObject;
            if (hitComponent.CompareTag("Battery")) {
                Debug.Log("Battery");
                if (Input.GetKey(KeyCode.E)) {
                    Destroy(hitComponent);
                    powerCurrent = powerTotal;
                }
                else if (Input.GetKey(KeyCode.F)) {
                    inspect(hitComponent);
                }
            }
        }
    }

}
