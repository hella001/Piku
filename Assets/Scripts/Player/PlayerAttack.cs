using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerControls controls;
    public Animator animator;
    public GameObject swordLeft;
    public GameObject swordRight;
    float direction = 0;
    bool isAttacking = false;

    PlayerMovement playerMovement;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        playerMovement = GetComponent<PlayerMovement>();

        controls.Land.AttackSword.performed += ctx =>
        {
            if (!isAttacking && animator != null)
            {
                isAttacking = true;
                animator.SetTrigger("sword");
                SwordAttack();
            }
        };

        controls.Land.AttackSword.canceled += ctx =>
        {
            if (isAttacking)
            {
                isAttacking = false;
                SwordAttckDone();
            }
        };
    }

    void Start() { }

    void Update() { }

    void SwordAttack()
    {
        if (playerMovement != null)
        {
            if (playerMovement.isFachingRight)
            {
                swordRight.SetActive(true);
            }
            else
            {
                swordLeft.SetActive(true);
            }
        }
    }

    void SwordAttckDone()
    {
        if (playerMovement != null)
        {
            if (playerMovement.isFachingRight)
            {
                swordRight.SetActive(false);
            }
            else
            {
                swordLeft.SetActive(false);
            }
        }
    }
}