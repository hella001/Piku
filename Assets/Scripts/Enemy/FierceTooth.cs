using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FierceTooth : MonoBehaviour
{

    GameObject target;
    public Transform borderCheck;
    public int enemyHp = 100;
    public Animator animator;
    public Slider enemyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealthBar.value = enemyHp;
        target = GameObject.FindGameObjectWithTag("Player");
        //Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(2f, 2f);
        }
        else
        {
            transform.localScale = new Vector2(-2f, 2f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword")) // Jika bersentuhan dengan pedang
        {
            // Mengurangi health musuh sebesar 25
            enemyHp -= 25;
            enemyHealthBar.value = enemyHp;
            animator.SetTrigger("damage");

            if (enemyHp <= 0) // Jika health musuh mencapai 0
            {
                animator.SetTrigger("death");
                GetComponent<BoxCollider2D>().enabled = false;
                this.enabled = false;
                //Destroy(gameObject); // Hancurkan musuh
            }
        }
    }

    public void PlayerDamage()
    {
        if (!target.GetComponent<PlayerCollision>().isInvincible)
        {
            target.GetComponent<PlayerCollision>().TakeDamage();
        }
    }
}
