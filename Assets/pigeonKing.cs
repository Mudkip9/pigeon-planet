using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class pigeonKing : MonoBehaviour

{
    public GameObject pigeonKingDialoguePanel;
    public Text kingPigeonDialogueText;
    public string[] pigeonKingDialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    public bool isTalking;

    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && !isTalking)
        {
            if (pigeonKingDialoguePanel.activeInHierarchy)
            {
                zeroText();
                isTalking = false;
            }
            else
            {
                pigeonKingDialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                isTalking = true;
            }
        }

        if (kingPigeonDialogueText.text == pigeonKingDialogue[index])
        {
            contButton.SetActive(true);
        }
    }



    public void zeroText()
    {
        kingPigeonDialogueText.text = "";
        index = 0;
        pigeonKingDialoguePanel.SetActive(false);
        isTalking = false;
    }

    IEnumerator Typing()
    {
        foreach (char letter in pigeonKingDialogue[index].ToCharArray())
        {
            kingPigeonDialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < pigeonKingDialogue.Length - 1)
        {
            index++;
            kingPigeonDialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("mainPlayer"))
        {
            playerIsClose = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("mainPlayer"))
        {
            playerIsClose = false;
            zeroText();
        }

    }
}

