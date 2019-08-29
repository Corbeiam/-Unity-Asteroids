using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsControll : MonoBehaviour {
    [SerializeField]
    private float fallSpeed = 2f;

    public int lifeAsteroid;
    public int score = 5;

    private PlayerControl playerControl;



    private void Start() {

        playerControl = FindObjectOfType<PlayerControl>();
    }

    private void Update() {

        

        if (transform.position.y < -5.5f) {
            Destroy(gameObject);
        }

        if ( lifeAsteroid <= 0) {

            playerControl.PlusScore(score);
            Destroy(gameObject);
        }

        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }


    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "BoltPlayer") {
            Destroy(other.gameObject);
            lifeAsteroid -= playerControl.damage;
        }
    }
}
