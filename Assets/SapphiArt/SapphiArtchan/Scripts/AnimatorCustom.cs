using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            animator.SetBool("param_idletowalk", true);
        }
    }
}
