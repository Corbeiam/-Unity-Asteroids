using System.Collections;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject[] asteroids;
    public GameObject[] enemy;



    private void Start() {

        StartCoroutine(Spawn());

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator Spawn() {
        while (true) {
            int value = Random.Range(0, asteroids.Length);
            Instantiate(asteroids[value], new Vector2 (Random.Range(-2.2f, 2.2f), 5.2f), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator SpawnEnemy() {
        while (true) {
            int value = Random.Range(0, enemy.Length);
            Instantiate(enemy[value], new Vector2 (Random.Range(-2.2f, 2.2f), 5.2f), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

}
