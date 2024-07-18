using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
//using UnityEngine.Windows;

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
    public Animator animator;
    private bool isPuased = false;


    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    public void Unpause()
    {
        this.isPuased = false;
    }

    public void Pause()
    {
        this.isPuased = true;
    }

    private bool IsPaused()
    {
        return this.isPuased;
    }

    public float moveSpeed = 5f;
    public Vector2 vector2;
    public Rigidbody2D rb;
    Vector2 movement;

    private void OnAnimatorIK(int layerIndex)
    {
        if(!this.IsPaused())
        {
            System.Console.WriteLine("I am in OnAnimatorIK");
        }
        
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
    private void Start()
    {  
            animator.gameObject.GetComponent<Animator>().enabled = false;
    }


    private void Update()
    {
        

 
        Vector3 vector3 = this.transform.position;
        if (!this.isPuased)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                animator.gameObject.GetComponent<Animator>().enabled = true;
                transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                animator.Play("Player_IdleRight");
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                animator.gameObject.GetComponent<Animator>().enabled = false;

            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                animator.gameObject.GetComponent<Animator>().enabled = true;
                transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
                animator.Play("Player_IdleLeft");
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                animator.gameObject.GetComponent<Animator>().enabled = false;

            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                animator.gameObject.GetComponent<Animator>().enabled = true;
                transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
                animator.Play("Player_IdleUp");
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                animator.gameObject.GetComponent<Animator>().enabled = false;

            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                animator.gameObject.GetComponent<Animator>().enabled = true;
                transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
                animator.Play("Player_IdleDown");
            }

            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                animator.gameObject.GetComponent<Animator>().enabled = false;

            }

            if (Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.Space))
            {
                Shoot();


            }
        }
       



    }

    private void Shoot() {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
    
}

