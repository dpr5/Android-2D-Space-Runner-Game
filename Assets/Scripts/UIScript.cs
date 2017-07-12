using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {

	

	public void startGame()
	{
		SceneManager.LoadScene("Level 1");
	}
    public void restartGame()
    {
        SceneManager.LoadScene("MainMenuUI");
    }
}
