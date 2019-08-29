using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int lifePlayer;
    public int damage;



    public Slider imgLife;
    public Text textLife;

    public Text textScore;
    private int valueScore;

    public GameObject panelGameOver;

    

    void Start()
    {
        valueScore = 0;
        panelGameOver.SetActive(false);
    }

    void Update()
    {
        if (imgLife.value == 0) {
            Time.timeScale = 0;
            panelGameOver.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Enemy") {

            imgLife.value -= 10;
            textLife.text = imgLife.value.ToString() + "%";
            Destroy(other.gameObject);
        }

        if (other.tag == "BoltEnemy") {
            imgLife.value -= 4;
            textLife.text = imgLife.value.ToString() + "%";
            Destroy(other.gameObject);
        }
        
    }

    public void PlusScore(int score) {
        valueScore += score;
        textScore.text = valueScore.ToString();
    }

}
