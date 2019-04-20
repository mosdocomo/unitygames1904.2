using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text SCORE;
    
    public bool start;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        SCORE.text = "SCORE : " + score;
    }
}
