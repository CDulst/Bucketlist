using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbody : MonoBehaviour
{
    [SerializeField] public float pushx = 10f;
    [SerializeField] public float pushy = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fly());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Fly(){
        if (transform.localScale.x == 1f){
            Vector2 Push = new Vector2(pushx,pushy);
            GetComponent<Rigidbody2D>().velocity = Push;
        }
        else
        {
            Vector2 Push = new Vector2(-(pushx),pushy);
            GetComponent<Rigidbody2D>().velocity = Push;
        }
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
