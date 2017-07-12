﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShotMover : MonoBehaviour
{


    Rigidbody2D rb;
    public float speed;
    public int destroyTime = 2;

    public GameObject explosion;
    public Text scoreText;
    public int scoreValue;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(this.gameObject, destroyTime);
    }


}