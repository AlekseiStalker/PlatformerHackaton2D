using UnityEngine;

public class DieSpace : MonoBehaviour {

    public GameObject respawn;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player")
        {
            other.transform.position = respawn.transform.position;
        }
	}
	

}
