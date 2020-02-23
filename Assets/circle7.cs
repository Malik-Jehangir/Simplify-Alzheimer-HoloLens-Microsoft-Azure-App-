using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle7 : MonoBehaviour
{
    public Transform center;
    public float radius = 4;
    public float angle = 0;
    public float period = 0.4f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angle += period * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius + center.transform.position.x; //x=cos(angle)*R+a;
        float y = 0;
        float z = Mathf.Sin(angle) * radius + center.transform.position.y; //y=sin(angle)*R+b;
        this.gameObject.transform.position = new Vector3(x, y, z);
    }
}
