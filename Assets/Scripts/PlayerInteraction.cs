using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Kicking")]
    public float kickForce = 10f; 
    public float kickRadius = 10f; 

    private Animator animator;
    private PlayerAnimation playerAnimation;

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isKicking");
            RaycastHit[] hitColliders = Physics.SphereCastAll(transform.position, kickRadius, transform.forward);
            foreach (RaycastHit collider in hitColliders)
            {
                if (collider.collider.CompareTag(Tags.ENEMY)) {
                    EnemyState enemyState = collider.collider.GetComponent<EnemyState>();
                    if (enemyState.state != State.KICKED)
                    {
                        Rigidbody enemyRb = collider.collider.GetComponent<Rigidbody>();
                        if (enemyRb != null)
                        {
                            enemyState.Kick();
                            StartCoroutine(KickEnemy(enemyRb));
                        }
                    }
                }
            }
        }
    }

    IEnumerator KickEnemy(Rigidbody enemyRb)
    {
        animator.Play("Kicking");

        yield return new WaitForSeconds(playerAnimation.GetAnimationClip("Kicking").length / 2);

        if (enemyRb != null)
        {
            QuestManager.Instance.UpdateQuestProgress(GoalType.Kick, 1);
            Vector3 kickDirection = (enemyRb.transform.position - transform.position).normalized;
            enemyRb.AddForce(kickDirection * kickForce, ForceMode.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward + Vector3.up, kickRadius);
    }

}
