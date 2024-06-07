using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCollision playerCollision = collision.gameObject.GetComponent<PlayerCollision>();
            if (playerCollision != null)
            {
                playerCollision.SetHealthToZero();
            }
            else
            {
                Debug.LogError("PlayerCollision not found on the Player object.");
            }
        }
    }
}
