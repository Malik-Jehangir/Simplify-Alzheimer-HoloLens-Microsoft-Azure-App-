using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boxjump : MonoBehaviour {
    public float moveSpeed=5.0f;
    public Vector3 moveVector=new Vector3(0,0,1);



    // Use this for initialization
    void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {


        transform.Translate(moveVector * moveSpeed * Time.deltaTime);

    

    }

   
    }

