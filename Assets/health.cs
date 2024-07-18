using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class health : MonoBehaviour
{
    public int healthLevel;
    public GameObject playerPanel;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    [SerializeField] Transform player;
    public Vector3 knockback;
    public bool dead;
    [SerializeField] Transform deathRoom;
    public GameObject mainPlayer;
    [SerializeField] Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerPanel.SetActive(false);
        healthLevel = 3;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            playerPanel.SetActive(true);
        }
        

        if (healthLevel <= 0)
        {
            heart1.SetActive(false);
            dead = true;
            mainPlayer.SetActive(false);
        }

        if (dead)
        {
            playerPanel.SetActive(false);
            player.transform.position = deathRoom.position;
        }
        
        if (healthLevel == 2)
        {
            heart3.SetActive(false);
        }

        if (healthLevel == 1)
        {
            heart2.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemyPigeon"))
        {
            healthLevel = healthLevel - 1;
            player.transform.position = player.position - knockback;
        }
    }
 }
