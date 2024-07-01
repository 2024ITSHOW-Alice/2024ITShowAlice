using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class happy1_Trig : MonoBehaviour
{
    public bool change;

    void Start()
    {
        change = false;
    }

    void Update()
    {
        if(change == true)
        {
            SceneManager.LoadScene("Ending_happy2");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            change = true;
        }
    }
}
