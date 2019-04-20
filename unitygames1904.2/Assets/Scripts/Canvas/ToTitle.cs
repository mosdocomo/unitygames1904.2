using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI機能の利用に必要なusing文
using UnityEngine.SceneManagement; // Scene機能の利用に必要なusing文

public class ToTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void JumpGame()
    {
        SceneManager.LoadScene("Ingame");
    }
}
