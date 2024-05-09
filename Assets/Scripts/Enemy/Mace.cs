using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mace : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;
    public int enemyHp = 100; // Health musuh
    public Slider enemyHealthBar;

    float startingY;
    int dir = 1;

    void Start()
    {
        enemyHealthBar.value = enemyHp;
        startingY = transform.position.y;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if (transform.position.y < startingY || transform.position.y > startingY + range)
            dir *= -1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword")) // Jika bersentuhan dengan pedang
        {
            // Mengurangi health musuh sebesar 25
            enemyHp -= 25;
            enemyHealthBar.value = enemyHp;

            if (enemyHp <= 0) // Jika health musuh mencapai 0
            {
                Destroy(gameObject); // Hancurkan musuh
            }
        }
    }
}