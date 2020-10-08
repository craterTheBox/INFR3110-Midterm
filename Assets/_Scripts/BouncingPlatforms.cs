using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class BouncingPlatforms : MonoBehaviour
{
    //Like the ObjSpin script, this is solely to make platforms move between two points
    [SerializeField] float speed;
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;

    bool reversed = false;
    float startTime;
    float dist, distA; //just needed for Lerp to work properly

    void Start()
    {
        transform.position = obj1.transform.position; //Starts it at obj1
        dist = Vector3.Distance(obj1.transform.position, obj2.transform.position);
    }

    void Update()
    {
        distA = ((Time.time - startTime) * speed) / dist;

        //Lerping time
        if (!reversed)
        {
            transform.position = Vector3.Lerp(obj1.transform.position, obj2.transform.position, distA);
        }
        else if (reversed)
        {
            transform.position = Vector3.Lerp(obj2.transform.position, obj1.transform.position, distA);
        }

        if (transform.position == obj1.transform.position)
        {
            reversed = false;
            startTime = Time.time;
            distA = (Time.time - startTime) / dist;
        }
        else if (transform.position == obj2.transform.position)
        {
            reversed = true;
            startTime = Time.time;
            distA = (Time.time - startTime) / dist;
        }
    }
}
