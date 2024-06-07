using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Dialogue3 : MonoBehaviour
{
    [SerializeField]
    private GameObject bgQuset;

    [SerializeField]
    private GameObject bgHome;

    [SerializeField]
    private GameObject gridHome;

    [SerializeField]
    private GameObject gridQuest;

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

    private bool gridHomeDisplayed;

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
        if (!gridHomeDisplayed)
        {
            ShowGridHome();
            gridHomeDisplayed = true;
        }
        else if (dialogueActivated)
        {
            if (step == 0)
            {
                ShowDialogueStep();
                step += 1;
            }
            else if (step >= speaker.Length)
            {
                dialogueCanvas.SetActive(false);
                dialogueCompleted = true;
                step = 0;
                HideGridHome();
                gridHomeDisplayed = false;
            }
            else
            {
                ShowDialogueStep();
                step += 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueActivated = true;
            if (questionButton != null)
            {
                questionButton.SetActive(true);
            }
            else
            {
                Debug.LogError("QuestionButton is not assigned.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueActivated = false;
            if (dialogueCanvas != null)
            {
                dialogueCanvas.SetActive(false);
            }
            if (questionButton != null)
            {
                questionButton.SetActive(false);
            }
        }
    }

    private void ShowGridHome()
    {
        if (gridHome != null)
        {
            bgHome.SetActive(true);
            bgQuset.SetActive(false);
            gridQuest.SetActive(false);
            gridHome.SetActive(true);
        }
        else
        {
            Debug.LogError("GridHome is not assigned.");
        }
    }

    private void HideGridHome()
    {
        if (gridHome != null)
        {
            bgHome.SetActive(false);
            bgQuset.SetActive(true);
            gridHome.SetActive(false);
            gridQuest.SetActive(true);
        }
        else
        {
            Debug.LogError("GridHome is not assigned.");
        }
    }

    private void ShowDialogueStep()
    {
        if (dialogueCanvas != null && speakerText != null && dialogueText != null && portraitImage != null)
        {
            dialogueCanvas.SetActive(true);
            if (step < speaker.Length && step < dialogueWords.Length && step < portrait.Length)
            {
                speakerText.text = speaker[step];
                dialogueText.text = dialogueWords[step];
                portraitImage.sprite = portrait[step];
            }
            else
            {
                Debug.LogError("Dialogue arrays are not properly set up.");
            }
        }
        else
        {
            Debug.LogError("Dialogue UI components are not assigned.");
        }
    }

    public bool IsDialogueCompleted()
    {
        return dialogueCompleted;
    }
}
