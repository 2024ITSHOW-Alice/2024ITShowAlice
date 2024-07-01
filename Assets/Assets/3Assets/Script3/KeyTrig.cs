using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyTrig : MonoBehaviour
{
    public bool changKey;

    void Start()
    {
        changKey = false;
    }

    void Update()
    {
        if(changKey == true) {
            SceneManager.LoadScene("Ending_happy3");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Key"){
            changKey = true;
        }
    }
}
