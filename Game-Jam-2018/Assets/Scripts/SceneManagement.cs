using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGame() {
        SceneManager.LoadScene("Scenes/ConradScene2", LoadSceneMode.Single);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
