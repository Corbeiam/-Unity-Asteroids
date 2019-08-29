using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private float fallSpeed = 2f; // Скорость
    public int Life; // Количество жизней
    public int score; // Количество очков за уничтожения объекта
    private PlayerControl playerControl; 

    public GameObject shot; // Пуля
    public Transform[] shotSpawn; // Координаты выстрела пулей
    public float fireRate; // частота стрельбы
    public float delay; // задержка 
    [Space]

    public Vector2 startWait;
    private float targetManeuver;
    public float dodge;
    public Vector2 maneuverTime;
    public float maneuverSpeed; // Скорость маневра
    public Vector2 maneuverWait;
    private float currentSpeed;

    

    private void Start() {

        currentSpeed = GetComponent<Rigidbody>().velocity.z;

        playerControl = FindObjectOfType<PlayerControl>();
        InvokeRepeating("Fire", delay, fireRate);

        StartCoroutine(Evade());
    }

    private void Update() {

        if (transform.position.y < -5.5f) {
            Destroy(gameObject);
        }

        if (Life <= 0) {

            playerControl.PlusScore(score);
            Destroy(gameObject);
        }

        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }

    void Fire() {

        for (int i = 0; i < shotSpawn.Length; i++) {
            Instantiate(shot, shotSpawn[i].position, shotSpawn[i].rotation);
        }
    }


    private void OnTriggerEnter(Collider other) {

        if (other.tag == "BoltPlayer") {
            Destroy(other.gameObject);
            Life -= playerControl.damage;
        }
    }

    // Маневрирование вражеского корабля

    IEnumerator Evade() {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true) {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);

            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));

            targetManeuver = 0;

            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    private void FixedUpdate() {

        float newManeuver = Mathf.MoveTowards(

        GetComponent<Rigidbody>().velocity.x,
        targetManeuver,
        maneuverSpeed * Time.deltaTime
        );

        GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, currentSpeed, 0.0f);


        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, -2f, 2f),
                Mathf.Clamp(GetComponent<Rigidbody>().position.y, 5.5f, 5f),
                0.0f                
            );
    }
}
