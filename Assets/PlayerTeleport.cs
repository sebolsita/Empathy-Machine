using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject player;

    public GameObject target;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnTriggerEnter(Collider other)

    {
        if(other.gameObject.tag == "Player")
        {
            player.transform.position = target.transform.position;
        }
    }
}
