using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_wheel : MonoBehaviour
{
    [SerializeField] public List<GameObject> waypoints;
    [SerializeField] public float Movement;
    public bool point1;
    public bool point2;



    // Start is called before the first frame update
    void Start()
    {
        point1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (point1 == true){

            Vector2 targetposition = waypoints[0].transform.position;
            float speed = Movement + Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetposition, speed);
            if (transform.position.x == targetposition.x){
                point1 = false;
                point2 = true;
            }
        }
        else if (point2 == true)
        {
            Vector2 targetposition = waypoints[1].transform.position;
            float speed = Movement + Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetposition, speed);
            if (transform.position.x == targetposition.x)
            {
                point2 = false;
                point1 = true;
            }
        }
    }
}
