using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerControls playerControls;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerControls = GetComponent<PlayerControls>();
    }

    void Update()
    {
        animator.SetInteger("pMove", playerControls.DirectionSpeed());
        animator.SetBool("pRoll", playerControls.Rolling());
        animator.SetBool("pHammer", playerControls.Hammering());
    }
}
