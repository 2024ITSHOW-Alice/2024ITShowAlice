using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gole_Miter : MonoBehaviour
{
    public GameObject ball;
    public GameObject gole;

    private float distance;

    private int Intdistance;

    public Text gole_m;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(ball.transform.position, gole.transform.position);
        Intdistance = (int)distance;
        gole_m.text = Intdistance.ToString() + " M";
    }
}
