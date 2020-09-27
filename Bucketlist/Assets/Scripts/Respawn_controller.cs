using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Respawn_controller : MonoBehaviour
{
    [SerializeField] public List<GameObject> checkpoints;
    public Player player;
    [SerializeField] public bool NoPlayerFound;
    [SerializeField] public bool ChangeFocus;
    [SerializeField] public GameObject spawnPlayer;
    [SerializeField] public GameObject FollowCamera;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<Player>();
        if (ChangeFocus){
            FollowCamera.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
            ChangeFocus = false;
        }
       
        if (player == null){
            if (NoPlayerFound == false){
                print("it works");
                Spawn();

            }
        

        }
       
    }
    private void Spawn(){
        NoPlayerFound = true;
        Instantiate(spawnPlayer, checkpoints[0].transform.position, Quaternion.identity);
        ChangeFocus = true;
        NoPlayerFound = false;
    }
}
