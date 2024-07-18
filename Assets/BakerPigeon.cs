using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class BakerPigeon : MonoBehaviour

{
    public GameObject bakerDialoguePanel;
    public Text bakerDialogueText;
    public string[] bakerDialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    public bool isTalking;
    private PlayerMovement playerMovement;
    
    // Start is called before the first frame update

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose && !isTalking)
        {
            if (bakerDialoguePanel.activeInHierarchy)
            {
                zeroText();
                isTalking = false;
            }
            else
            {
                bakerDialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                isTalking = true;

                if (GameObject.FindGameObjectWithTag("mainPlayer"))
                {
                    playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
                }
                playerMovement.Pause();
            }
        }

        if(bakerDialogueText.text == bakerDialogue[index])
        {
            contButton.SetActive(true);
        }
    }    

    public void zeroText()
    {
        bakerDialogueText.text = "";
        index = 0;
        bakerDialoguePanel.SetActive(false);
        isTalking = false;

        if (GameObject.FindGameObjectWithTag("mainPlayer"))
        {
            playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        }
        playerMovement.Unpause();
    }

    IEnumerator Typing()
    {
        foreach(char letter in bakerDialogue[index].ToCharArray())
        {
            bakerDialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < bakerDialogue.Length - 1)
        {
            index++;
            bakerDialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText() ;
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
