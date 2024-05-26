using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private Dialogue dialogueScript;

    private void Start()
    {
        // Mencari referensi ke skrip Dialogue
        dialogueScript = FindObjectOfType<Dialogue>();

        if (dialogueScript == null)
        {
            Debug.LogError("Dialogue script not found. Make sure there is a Dialogue component in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && dialogueScript != null && dialogueScript.IsDialogueCompleted())
        {
            SceneManager.LoadScene("Level1");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
