using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour{
    public Transform target;
    public float speed = 4f;
    public float rotateSpeed = 0.025f;
    private Rigidbody2D rb;
    [SerializeField] Transform enemy;
    public Vector2 zero;
    public GameObject pigeonEnemy;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if (!target){
            GetTarget();
        } else {
            RotateTowardsTarget();
            GetTarget();
        }

        if (target)
        {
            rb.velocity = transform.up * speed;
        }

        if (!target)
        {
            rb.velocity = (zero);
        }
    }





private void RotateTowardsTarget() { 
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3 (0,0,angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void GetTarget () {
        if (GameObject.FindGameObjectWithTag("mainPlayer")) 
        {
            target = GameObject.FindGameObjectWithTag("mainPlayer").transform;
        }
        else
        {
            Destroy(pigeonEnemy);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(pigeonEnemy);
        }
    }


}

