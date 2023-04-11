using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;
using UnityEngine.AI;

public class MelleAttacker : MonoBehaviour{
    private Animator animator;
    public GameObject player;
    public float visionRange;
    public float attackRange;
    public float health;
    public bool isAlive;
    public GameObject healthBar;
    
    void Start(){
        animator = GetComponent<Animator>();
    }
    void Update() {
        updateHealthBar();
        Vector3 directionVector = player.transform.position - transform.position;
        directionVector.y = 0;
        if (!isAlive) {
            animator.SetBool("attack", false);
            animator.SetBool("walking", false);
            animator.SetBool("dead", true);
        }else if (directionVector.magnitude <= visionRange){
            if (directionVector.magnitude <= attackRange){
                animator.SetBool("attack", true);
                animator.SetBool("walking", false);
                player.GetComponent<Player>().takeDamage(1 * Time.deltaTime);
            }else {
                GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
                // transform.rotation = Quaternion.LookRotation(directionVector);
                // transform.Translate(directionVector.normalized * Time.deltaTime);
                animator.SetBool("attack", false);
                animator.SetBool("walking", true);
            }
        }else{
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            animator.SetBool("attack", false);
            animator.SetBool("walking", false);
        }
    }
    
    public void takeDamage(float damage){
        if (isAlive){
            health -= damage;
            if (health <= 0) {
                isAlive = false;
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
            }
        }
        updateHealthBar();
    }

    private void updateHealthBar() {
        Transform transform = healthBar.transform;
        transform.localScale = new Vector3(
            health * 1.04f / 100f,
            transform.localScale.y,
            transform.localScale.z
            );
        transform.localPosition = new Vector3(
            (1.04f - health * 1.04f / 100f) / 2,
            transform.localPosition.y,
            transform.localPosition.z
        );
    }
}