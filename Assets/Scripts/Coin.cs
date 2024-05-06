using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerManager.numberOfCoins++;
            AudioManager.instance.Play("Coins");
            //savecoin
            PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
            //savecoinEnd
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
