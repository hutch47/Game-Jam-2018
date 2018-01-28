using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public Health hp;
    public bool isAttacking;
    public Image HpBar;

	// Use this for initialization
	void Start () {
        hp = GetComponent<Health>();
        hp.value = 50f;
        hp.max = 50f;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void UpdateHealthBar() {
        HpBar.fillAmount = hp.value / hp.max;
        Debug.Log("Ow");
    }
    public void OnHit(GameObject source, float dmg) {
        hp.value -= dmg;
        UpdateHealthBar();
        if (hp.value <= 0) {
            SceneManager.LoadScene("Scenes/Ded", LoadSceneMode.Single);
        }
    }


    /*
     TO DO:
        Encase HP with a setter/getter
     */
}
