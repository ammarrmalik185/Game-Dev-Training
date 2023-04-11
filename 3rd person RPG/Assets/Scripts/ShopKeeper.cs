using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour {
    public GameObject player;
    public float visionRange;
    public GameObject toolTip;
    public GameObject toolTipText;
    void Update() {
        Vector3 directionVector = player.transform.position - transform.position;
        directionVector.y = 0;
        if (directionVector.magnitude <= visionRange) {
            toolTipText.GetComponent<Text>().text = "Press E to buy armor";
            toolTip.SetActive(true);
            if (Input.GetKey(KeyCode.E)) {
                player.GetComponent<Player>().getArmor();
            }
        }
        else {
            toolTip.SetActive(false);
        }
    }
}
