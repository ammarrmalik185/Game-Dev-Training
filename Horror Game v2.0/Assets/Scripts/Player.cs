using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] private InspectCamera1 inspectCamera;
    [SerializeField] private Image healthBar;
    internal bool hasWheel;
    [SerializeField] private float currentHealth;
    [SerializeField] private float totalHealth;


    private bool Keydown_E;
    private bool Keydown_F;
    void Start() {
        hasWheel = false;
        Keydown_E = false;
        Keydown_F = false;
    }
    void Update() {
        healthBar.fillAmount = currentHealth / totalHealth;
        getKeys();
        lookingAt();
    }

    void getKeys() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Keydown_E = true;
        }else if (Input.GetKeyUp(KeyCode.E)) {
            Keydown_E = false;
        }
        
        if (Input.GetKeyDown(KeyCode.F)) {
            Keydown_F = true;
        }else if (Input.GetKeyUp(KeyCode.E)) {
            Keydown_F = false;
        }
    }
    void lookingAt() {
        // Debug.Assert(Camera.main != null, "Camera.main != null");
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f)) {
            
            GameObject hitComponent = hit.collider.gameObject;
            if (hitComponent.CompareTag("Wheel")) {
                Debug.Log("Wheel");
                if (Keydown_E) {
                    Destroy(hitComponent);
                    hasWheel = true;
                }else if (Keydown_F) {
                    inspect(hitComponent);
                }
            }else if (hitComponent.CompareTag("Health")) {
                Debug.Log("Health");
                if (Keydown_E) {
                    Destroy(hitComponent);
                    currentHealth = totalHealth;
                }else if (Keydown_F) {
                    inspect(hitComponent);
                }
            }
        }
    }
    void inspect(GameObject inspectElement) {
        Debug.Log("hit torch");
        inspectCamera.goToInspect(inspectElement);
        
    }

    
}
