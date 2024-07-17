using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firingpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject gunn = GameObject.FindWithTag("mainPlayer");
        //Quaternion quaternion = this.transform.rotation;bullet 
        //GameObject bullet = GameObject.FindWithTag("firingPoint");

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, -90f);
            Vector3 gunPosition = gunn.transform.position;
            transform.position = new Vector3(gunPosition.x + 1.6f, gunPosition.y + 0.4f, -2);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            Vector3 gunPosition = gunn.transform.position;
            transform.position = new Vector3(gunPosition.x - 1.6f, gunPosition.y + 0.4f, -2);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }
    }
}
