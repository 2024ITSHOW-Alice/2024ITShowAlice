using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParText : MonoBehaviour
{
    public TextMeshProUGUI par; // 플레이어 타수
    
    public int num; // 일정타수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        par.text = num.ToString();
    }
}
