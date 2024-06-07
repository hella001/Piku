using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Dialogue1 : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueCanvas;

    [SerializeField]
    private TMP_Text speakerText;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private Image portraitImage;

    // Dialogue
    [SerializeField]
    private string[] speaker;

    [SerializeField]
    [TextArea]
    private string[] dialogueWords;

    [SerializeField]
    private Sprite[] portrait;

    private bool dialogueActivated;
    private bool dialogueCompleted;
    private int step;

    // Tambahkan referensi untuk QuestionButton
    [SerializeField]
    private GameObject questionButton;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();

        // Menambahkan event handler untuk action Dialogue
        playerControls.Land.Dialogue.performed += OnDialogue;
    }

    private void OnEnable()
    {
        playerControls.Land.Enable();
    }

    private void OnDisable()
    {
        playerControls.Land.Disable();
    }

    private void OnDialogue(InputAction.CallbackContext context)
    {
        if (dialogueActivated)
        {
            if (step >= speaker.Length)
            {
                dialogueCanvas.SetActive(false);
                dialogueCompleted = true;
                step = 0;
            }
            else
            {
                dialogueCanvas.SetActive(true);
                speakerText.text = speaker[step];
                dialogueText.text = dialogueWords[step];
                portraitImage.sprite = portrait[step];
                step += 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueActivated = true;
            questionButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueActivated = false;
            dialogueCanvas.SetActive(false);
            questionButton.SetActive(false);
        }
    }

    public bool IsDialogueCompleted()
    {
        return dialogueCompleted;
    }
}
