using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneChange(){
        SceneManager.LoadScene(0);
    }
}
