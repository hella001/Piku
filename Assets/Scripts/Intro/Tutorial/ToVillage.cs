using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToVillage : MonoBehaviour
{
    private Dialogue1 dialogueScript;

    // Start is called before the first frame update
    void Start()
    {
        // Mencari referensi ke skrip Dialogue1
        dialogueScript = FindObjectOfType<Dialogue1>();

        if (dialogueScript == null)
        {
            Debug.LogError("Dialogue script not found. Make sure there is a Dialogue1 component in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && dialogueScript != null && dialogueScript.IsDialogueCompleted())
        {
            SceneManager.LoadScene("Village");
        }
    }
}
