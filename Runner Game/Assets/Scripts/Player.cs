using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public GameObject lossUI;
    public GameObject winUI;
    public GameObject[] scoreUIs;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("obstacle")) {
            lossUI.SetActive(true);
            StaticValues.gameIsRunning = false;
            StaticValues.gameIsEnded = true;
            
        }else if (other.CompareTag("point")) {
            Destroy(other.gameObject);
            StaticValues.score += 1;
            for (int index=0; index<scoreUIs.Length; index++){
                scoreUIs[index].GetComponent<Text>().text = "Score: " + StaticValues.score;
            }
        }else if (other.CompareTag("Finish")) {
            winUI.SetActive(true);
            StaticValues.gameIsRunning = false;
            StaticValues.gameIsEnded = true;
        }
    }
}
