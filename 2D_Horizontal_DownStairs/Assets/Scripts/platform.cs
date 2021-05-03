﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    Vector3 movement;
    GameObject topLine;
    public float speed;

    void Start()
    {
        movement.y = speed;
        topLine = GameObject.Find("上邊界");
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        transform.position += movement * Time.deltaTime;

        if(transform.position.y >= topLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
