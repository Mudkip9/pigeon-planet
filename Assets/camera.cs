using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = player.transform.position + new Vector3(0, 1, -5);
        }
    }
}
