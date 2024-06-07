using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isInvincible = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            TakeDamage();
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        isInvincible = true;
        yield return new WaitForSeconds(3);
        isInvincible = false;
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage()
    {
        HealthManager.health--;
        if (HealthManager.health <= 0)
        {
            TriggerGameOver();
        }
        else
        {
            StartCoroutine(GetHurt());
        }
    }

    public void SetHealthToZero()
    {
        HealthManager.health = 0;
        TriggerGameOver();
    }

    private void TriggerGameOver()
    {
        PlayerManager.isGameOver = true;
        AudioManager.instance.Play("GameOver");
        gameObject.SetActive(false);

        // Display game over screen
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager != null)
        {
            playerManager.gameOverScreen.SetActive(true);
        }
    }
}
