using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public GameObject startButton;
    public GameObject player;
    public Vector3 startLocation;
    public GameObject startMenu;
    public GameObject enemy;
    public GameObject playerPanel;

    // Start is called before the first frame update
    void Start()
    {
        enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonIsPressed()
    {
        player.SetActive(true);
        startMenu.SetActive(false);
        player.transform.position = (startLocation);
        enemy.SetActive(true);
        playerPanel.SetActive(true);
    }
}
