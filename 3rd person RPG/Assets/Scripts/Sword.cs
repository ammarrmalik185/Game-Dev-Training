using UnityEngine;

public class Sword : MonoBehaviour {
    public float damage;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            GetComponent<Animator>().SetBool("attack", true);
        }

        if (Input.GetKeyUp(KeyCode.Q)) {
            GetComponent<Animator>().SetBool("attack", false);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            other.gameObject.GetComponent<MelleAttacker>().takeDamage(damage);
            Debug.Log("Hit");
        }  
    }
}
