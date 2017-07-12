using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    
    Transform myTrans;
    Rigidbody2D myBody;
    
    
    public Boundary boundary;
    AudioSource bulletSound;
    public AudioClip impact;

    AudioSource explosionSound;
    public AudioClip boom;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    public Text Health;
    private int health =3;
    private int damage = 1;

    public GameObject explosion;

    public GameObject hearts3;
    public GameObject hearts2;
    public GameObject hearts1;

    private spawnWave gameController;

    public Button restartButton;
    public Text gameOverText;
    private bool restart;
    private bool gameOver;
   





    void Start()
    {
        explosionSound = GetComponent<AudioSource>();
        gameOver = false;
        restart = false;

        restartButton.gameObject.SetActive(false);
        gameOverText.text = "";

        myBody = this.GetComponent<Rigidbody2D>();//Unity 5+
        bulletSound = GetComponent<AudioSource>();//Unity 5+
        myTrans = this.transform;
        health = 3; 
    }


    void FixedUpdate()
    {
        myBody.position = new Vector3
         (
             Mathf.Clamp(myBody.position.x, boundary.xMin, boundary.xMax),
             0.0F,
             Mathf.Clamp(myBody.position.y, boundary.yMin, boundary.yMax)
         );
    }

    public void Move(float horizonalInput)
    {
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizonalInput * speed;
        myBody.velocity = moveVel;
    }
 
    public void shoot()
    {
        nextFire = Time.time * fireRate;        
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        bulletSound.PlayOneShot(impact, 0.7F);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "EnemyFire")
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            health = health - damage;
            if(health == 3)
            {
                hearts3.SetActive(true);
                explosionSound.PlayOneShot(boom, 0.7F);
            }
            if (health == 2)
            {
                hearts2.SetActive(true);
                hearts3.SetActive(false);
            }
            if (health == 1)
            {
                hearts1.SetActive(true);
                hearts2.SetActive(false);
            }
            if (health == 0)
            {
                hearts1.SetActive(false);
                Destroy(this.gameObject);
                GameOver();
            }
            
        }
    }

    public void GameOver()
    {
        gameOverText.text = " Game Over";
        gameOver = true;
        restartButton.gameObject.SetActive(true);
    }
}