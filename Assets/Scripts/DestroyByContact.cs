using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public int scoreValue;
	private spawnWave gameController;
    public bool isDestroyed = false;
    AudioSource explosionSound;
    public AudioClip boom;
    
   
	public AudioClip explosionsound;

	// Use this for initialization
	void Start () {
        explosionSound = GetComponent<AudioSource>();

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <spawnWave>();
		}
		if(gameController == null)
		{
			Debug.Log("Can not find game controller");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "bolt")
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
            
            Instantiate(explosion, transform.position, transform.rotation);
			gameController.AddScore(scoreValue);
            isDestroyed = true;

        }
	}
}
