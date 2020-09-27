using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backstab : MonoBehaviour
{
    public GameObject button;
    public Player player;
    public bool Playerin;
    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("wtf");
        if (collision.gameObject.tag == "Player"){
            button.GetComponent<SpriteRenderer>().enabled = true;
            Playerin = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Playerin = false;
    }
    private void Update()
    {
        player = FindObjectOfType<Player>();
        button = GameObject.FindGameObjectWithTag("Circle");
        if (Playerin){
            if(Input.GetButtonDown("Cancel")){
                button.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<AudioSource>().Play(0);
                player.GetComponent<Animator>().SetBool("Attack", true);
                StartCoroutine(StopAnimation());
                Playerin = false;

            }
        }
    }
    private IEnumerator StopAnimation(){
        yield return new WaitForSeconds(0.5f);
        print("Something is wrong");
        EnemyHit();


    }
    public void EnemyHit(){
        transform.parent.GetComponent<Enemy>().Death();
    }
}
