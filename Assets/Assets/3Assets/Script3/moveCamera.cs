using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class moveCamera : MonoBehaviour
{
    public Transform target;

   void Start()
    {
        transform.position = new Vector3(0f, 0f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && target.position.x > 0f)
        {
            transform.position = new Vector3(target.position.x, 0f, transform.position.z);
        }
    } 

    void ExecuteAction(object sender, EventArgs e)
    {
        transform.position = new Vector3(0f, 0f, -10f);
    }
}
