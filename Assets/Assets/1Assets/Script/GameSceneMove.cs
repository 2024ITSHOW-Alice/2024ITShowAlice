using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMove : MonoBehaviour
{

    public void SceneCtrl()
    {
        SceneManager.LoadScene("Opening_Scene"); //어떤  씬 이름으로 이동할것인지
    }

}
