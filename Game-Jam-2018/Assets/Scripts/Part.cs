using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour {

    public int partnum;
    public GameManager gm;

    // Use this for initialization
    void Start() {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Tower/Tower" + (partnum + 1));
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Part get!");
            gm.collectPart();
            Destroy(gameObject);
        }
        
    }
}
