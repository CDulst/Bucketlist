using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public ParticleSystem Boom;
    [SerializeField] public GameObject Collider;
    [SerializeField] public float pushx;
    [SerializeField] public float pushy;
    [SerializeField] public AudioClip Tick;
    [SerializeField] public AudioClip Explosion;
    public Deathbody DeadBody;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        DeadBody = FindObjectOfType<Deathbody>();
        fly();
        StartCoroutine(Explode());

    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<Player>();
        DeadBody = FindObjectOfType<Deathbody>();
    }
    
    private IEnumerator Explode(){
        float seconds = 0.1f;
        for (int i = 0; i < 10; i++){
            GetComponent<SpriteRenderer>().color = Color.white;
    
            yield return new WaitForSeconds(seconds);
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<AudioSource>().Play(0);

            yield return new WaitForSeconds(seconds);
            seconds = seconds - 0.01f;

        }
        
        Instantiate(Boom, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(Explosion, Camera.main.transform.position, 0.2f);
        if (Collider.GetComponent<Bombcollider>().Inrange){
            player.Die();
        }
        Destroy(gameObject);

    }
    private void fly(){
        if (DeadBody.GetComponent<Transform>().localScale.x == 1f)
        {
            Vector2 Push = new Vector2(pushx, pushy);
            GetComponent<Rigidbody2D>().velocity = Push;
        }
        else
        {
            Vector2 Push = new Vector2(-(pushx), pushy);
            GetComponent<Rigidbody2D>().velocity = Push;
        }
    }
}
