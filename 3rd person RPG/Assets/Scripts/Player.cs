using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {
    public float health;
    public float armor;
    public float battery;

    public float max_health;
    public float max_armor;
    public float max_battery;
    
    public bool hasArmor;
    public bool hasTorch;

    public GameObject inspectCamera;

    public GameObject healthBar;
    public GameObject armorBar;
    public GameObject batteryBar;

    public GameObject torch;
    public GameObject torchLight;
    
    public GameObject armorBarContainer;
    public GameObject batteryBarContainer;

    void Start() {
        updateUI();
    }

    private void Update() {
        updateTorch();
        lookingAt();
    }

    private void updateTorch() {
        if (battery >= 0) {
            battery -= 1 * Time.deltaTime;
        } else {
            hasTorch = false;
        }

        if (hasTorch) {
            torch.SetActive(true);
            torchLight.GetComponent<Light>().intensity = battery / max_battery * 10;
        } else {
            torch.SetActive(false);
        }
        updateUI();
    }

    public void getTorch() {
        hasTorch = true;
        battery = max_battery;
    }
    
    public void getArmor() {
        hasArmor = true;
        armor = 100;
        updateUI();
    }
    
    void updateUI() {
        healthBar.GetComponent<Image>().fillAmount = health/max_health;
        if (hasArmor) {
            armorBar.GetComponent<Image>().fillAmount = armor/max_armor;
            armorBarContainer.SetActive(true);
        }
        else {
            armorBarContainer.SetActive(false);
        }
        if (hasTorch) {
            batteryBar.GetComponent<Image>().fillAmount = battery/max_battery;
            batteryBarContainer.SetActive(true);
        }
        else {
            batteryBarContainer.SetActive(false);
        }
    }

    void inspect(GameObject inspectElement) {
        Debug.Log("hit torch");
        inspectCamera.GetComponent<InspectCamera>().goToInspect(inspectElement);
        
    }
    void lookingAt() {
        Debug.Assert(Camera.main != null, "Camera.main != null");
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50f)) {
            GameObject hitComponent = hit.collider.gameObject;
            if (hitComponent.CompareTag("Torch")) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    Destroy(hitComponent);
                    getTorch();
                }else if (Input.GetKeyDown(KeyCode.F)) {
                    inspect(hitComponent);
                }

            }else if (hitComponent.CompareTag("Enemy")) {
                if (Input.GetKeyDown(KeyCode.Q)) {
                    hitComponent.GetComponent<MelleAttacker>().takeDamage(10);
                }
            };
        }
    }
    
    public void takeDamage(float amount) {
        if (hasArmor) {
            armor -= amount;
            if (armor <= 0) {
                hasArmor = false;
            }
        }
        else {
            health -= amount;
            if (health <= 0) {
                SceneManager.LoadScene("SampleScene");
            }
        }
        updateUI();
    }
    
    
    
}
