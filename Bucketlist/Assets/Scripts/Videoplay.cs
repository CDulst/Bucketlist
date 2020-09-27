using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Videoplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Wingflying"){
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "Wingflying.mp4");
        }
        if (gameObject.tag == "Moonlanding")
        {
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "Moonlanding.mp4");
        }
        if (gameObject.tag == "Fighting Kangoroo")
        {
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "Fighting Kanguroo.mp4");
        }
        if (gameObject.tag == "Climbing Mountains")
        {
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "Climbing Mount Everest.mp4");
        }
        if (gameObject.tag == "Climbing Pyramids")
        {
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "Climbing pyramid.mp4");
        }
        if (gameObject.tag == "Dream Drop Dubai")
        {
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "Dream Drop Dubai.mp4");
        }
        if (gameObject.tag == "Airsurfing")
        {
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "Airsurfing.mp4");
        }
        if (gameObject.tag == "Riding Rollercoaster")
        {
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "Riding Highest Rollercoaster.mp4");
        }
        if (gameObject.tag == "Race")
        {
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "5 second clip.mp4");
        }
        if (gameObject.tag == "World Cruise")
        {
            GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "World Cruise.mp4");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
