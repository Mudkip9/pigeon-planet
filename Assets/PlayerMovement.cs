using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    public SpriteRenderer spriteRenderer;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }




    public float moveSpeed = 5f;
    public Vector2 vector2;
    public Rigidbody2D rb;
    Vector2 movement;

    private void OnAnimatorIK(int layerIndex)
    {
        System.Console.WriteLine("I am in OnAnimatorIK");
    }

    private void LateUpdate()
    {
        
    }

    private void OnGUI()
    {
        System.Console.WriteLine("I am in OnGUI");
    }

    private void OnPreCull()
    {
        System.Console.WriteLine("I am in OnPreCull");
        
    }

    private void OnPreRender()
    {
        System.Console.WriteLine("I am in OnPreRender");
    }

    private void OnPostRender()
    {
        System.Console.WriteLine("I am in OnPostRender");
    }

    public Vector3 FindMe()
    {
        return this.transform.position;
    }



    // Update is called once per frame
    //void Update()
    //{
    //    //movement.x = Input.GetAxisRaw("Horizontal");
    //    //movement.y = Input.GetAxisRaw("Vertical");

    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        // w was pressed
    //        Vector3 movement = new Vector3(x + 0.01f, 0, z + 0.01f);
    //        transform.Translate(movement * 0.002f * Time.deltaTime,);
    //        transform.get
    //    }

    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        // w was pressed
    //        Vector3 movement = new Vector3(x - 0.01f, 0, z - 0.01f);
    //        transform.Translate(movement * 0.002f * Time.deltaTime);
    //    }

    //}



    private void Update()
    {
        Vector3 vector3 = this.transform.position;  

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            ChangeSprite(rightSprite);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            ChangeSprite(leftSprite);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
            ChangeSprite(upSprite);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
            ChangeSprite(downSprite);

        }
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
        {
            Shoot();

        }
    }

    private void Shoot() {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
    
}

