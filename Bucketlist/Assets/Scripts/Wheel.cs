using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();

    }
    private void Update()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            if (player.Death == false)
            {
                player.Die();
            }
        }
       
       

    }


}
