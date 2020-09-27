using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool turning;
    public Player player;
    public bool death;
    public bool turnSwitch;
    [SerializeField] public GameObject Deathbody1;
    [SerializeField] public GameObject Deathbody2;
    [SerializeField] public GameObject Bomb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirection());
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(ChangeDirection());
    }
    private IEnumerator ChangeDirection(){
        if (turnSwitch){

        
        if (!turning)
        {
            turning = true;
            yield return new WaitForSeconds(2f);
            if (!death){
               
                transform.localScale = new Vector2(-1, 1);
            }
            yield return new WaitForSeconds(3f);
            if (!death){

                transform.localScale = new Vector2(1, 1);
            }
            turning = false;
        }
        }

    }
    public void Death(){
        death = true;
        print("hell0");
        player.GetComponent<Animator>().SetBool("Attack", false);
        if (transform.localScale.x == 1f){
            Instantiate(Deathbody1, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Deathbody2, transform.position, Quaternion.identity);
        }
        Instantiate(Bomb, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
