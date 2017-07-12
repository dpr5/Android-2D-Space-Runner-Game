using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tumble : MonoBehaviour {



    public float rotateAsteroid;
    private Rigidbody rb;
    public int destroyTime = 2;

    





    void start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * rotateAsteroid;
    }



    void Update()
    {
        if (this.gameObject.tag == "Asteroid")
        {
            Destroy(this.gameObject, destroyTime); //Destroy(clone, destroyTime);
        }
    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bolt")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            score = score + 10;
        }
    }*/

    
}

