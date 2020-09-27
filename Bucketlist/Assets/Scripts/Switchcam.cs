using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Audio;
public class Switchcam : MonoBehaviour
{
    [SerializeField] public GameObject Door;
    [SerializeField] public CinemachineVirtualCamera CameraPlayer;
    [SerializeField] public CinemachineVirtualCamera CameraDoor;
    [SerializeField] public GameObject Music;
   

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            CameraDoor.Follow = Door.transform;
            CameraDoor.enabled = true;
            CameraPlayer.enabled = false;
            Music.GetComponent<AudioSource>().volume = 0.025f;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            CameraDoor.enabled = false;
            CameraPlayer.enabled = true;
            Music.GetComponent<AudioSource>().volume = 0.1f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
