using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicEffects : MonoBehaviour {

    public DestroyByContact contact;
    AudioSource explosionSound;
    public AudioClip explosionsound;

    // Use this for initialization
    void Start () {
		AudioSource explosionSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        bool myv = contact.isDestroyed;
        if (myv == true){
            //Debug.Log("It worked");
            explosionSound.PlayOneShot(explosionsound);
        }
	}
}
