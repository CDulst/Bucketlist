using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Video;


public class door : MonoBehaviour
{
    public Animator anim;
    [SerializeField] public GameObject button;
    [SerializeField] public CinemachineVirtualCamera Videocamera;
    [SerializeField] public CinemachineVirtualCamera CameraDoor;
    [SerializeField] public AudioClip Zoomin;
    [SerializeField] public AudioClip Victory;
    public GameObject Video;
    [SerializeField] public UI uicontroller;
    [SerializeField] public GameObject respawnpoint;
     
    public Player player;

    public bool Playerin;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        button = GameObject.FindGameObjectWithTag("Circle");
        




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            anim.SetBool("Open", true);
            GetComponent<AudioSource>().Play(0);
            Videocamera.Follow = gameObject.transform;
            button.GetComponent<SpriteRenderer>().enabled = true;
            Playerin = true;
        }
       

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Open", false);
            GetComponent<AudioSource>().Play(0);
            button.GetComponent<SpriteRenderer>().enabled = false;
            Playerin = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        button = GameObject.FindWithTag("Circle");
        player = FindObjectOfType<Player>();
        if (Playerin){
            if (Input.GetButtonDown("Cancel")){
                Playerin = false;
                player.Death = true;
                player.Cutscene = true;
                StartCoroutine(Videofunc());
               

            }
        }
    }
    private IEnumerator Videofunc(){
        CameraDoor.enabled = false;
        Videocamera.enabled = true;
        AudioSource.PlayClipAtPoint(Zoomin, Camera.main.transform.position, 2);
        uicontroller.UpdateUI(gameObject);
        respawnpoint.transform.position = gameObject.transform.position;
        button.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<SpriteRenderer>().sortingOrder = 0;
        yield return new WaitForSeconds(2f);
        Video.SetActive(true);
        AudioSource.PlayClipAtPoint(Victory, Camera.main.transform.position, 2);
        yield return new WaitForSeconds(5f);
        Video.SetActive(false);
        CameraDoor.enabled = true;
        Videocamera.enabled = false;
        button.GetComponent<SpriteRenderer>().enabled = true; 
        player.GetComponent<SpriteRenderer>().sortingOrder = 2;
        player.Death = false;
        player.Cutscene = false;

    }
}
