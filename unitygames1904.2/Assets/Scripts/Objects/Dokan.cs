﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dokan : MonoBehaviour
{
    public GameManager GameManager;

    public Vector2 vSpeed;
    public bool flgMove;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.name = "block";
        speed = -4.0f;
        vSpeed = new Vector2(speed, 0);
        flgMove = false;
        ChkStart();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void ChkStart()
    {


        ShowSlide();
    }

    void ShowSlide()
    {// 動き始める処理

        this.GetComponent<Rigidbody2D>().velocity = vSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {// なんかぶつかった時の処理
        GameObject obj = collision.gameObject;
        switch (obj.name)
        {
            case "Daruma": ; break;
            case "DeadLine": Destroy(this.gameObject); break;
        }
    }

}
