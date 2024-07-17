using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class gun : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite leftGun;
    public Sprite rightGun;
    public Sprite upGun;
    public Sprite downGun;
    public double right;


    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
        GameObject adam = GameObject.FindWithTag("mainPlayer");

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ChangeSprite(rightGun);
            
            Vector3 adamsPosition = adam.transform.position;            
            transform.position = new Vector3(adamsPosition.x + 2f, adamsPosition.y, -5);

            //Rigidbody2D adamRigidbody2D = adam.GetComponent<Rigidbody2D>();
            //adamRigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeSprite(leftGun);            
            Vector3 adamsPosition = adam.transform.position;
            transform.position = new Vector3(adamsPosition.x - 2f, adamsPosition.y, -5);            
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            ChangeSprite(upGun);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            ChangeSprite(downGun);

        }
    }
}
