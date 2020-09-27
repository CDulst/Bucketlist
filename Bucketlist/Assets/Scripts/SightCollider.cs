using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCollider : MonoBehaviour
{
    [SerializeField] public Player Player;
    [SerializeField] public GameObject Enemy;
    [SerializeField] public ParticleSystem Clocks;
    [SerializeField] public AudioClip Explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            Instantiate(Clocks, Enemy.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(Explosion, Camera.main.transform.position, 0.2f);
            Player.Die();
            Destroy(Enemy);

        }


    }
    private void Start()
    {
        Player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        Player = FindObjectOfType<Player>();
    }
}
