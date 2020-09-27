using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public scenecontroller scenemanag;
    public Text currentTime;
    float timek = 600.00f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = GetComponent<Text>();
        StartCoroutine(Countdown());
      
    }

    // Update is called once per frame
    void Update()
    {
        if (timek <= 0f){
            scenemanag = FindObjectOfType<scenecontroller>();
            scenemanag.LoadNextScene();
        }
    }
    IEnumerator Countdown(){
        while (timek > 0){
            yield return new WaitForSeconds(Time.deltaTime);
            timek = timek - Time.deltaTime;
            print(timek);
            currentTime.text = timek.ToString("F2");

        }
       
}
}
