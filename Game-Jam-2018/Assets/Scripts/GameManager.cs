using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int partsTotal;
    public int partsCollected;

    public GameObject partPrefab;
    private GameObject partClone;

    public Vector2 playArea;
    private bool gameWon;



	// Use this for initialization
	void Start () {
        gameWon = false;
        partsCollected = 0;
        for (int i = 0; i < partsTotal; i++) {
            partClone = Instantiate(partPrefab, new Vector2(Random.Range(-playArea.x/2, playArea.x/2), Random.Range(transform.position.y-playArea.y/2, transform.position.y + playArea.y/2)), partPrefab.transform.rotation, gameObject.transform);
            partClone.GetComponent<Part>().partnum = i;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void collectPart() {
        partsCollected++;
        if (partsCollected == partsTotal) {
            gameWon = true;
            // Run game won scene
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, (Vector3)playArea);
    }

}
