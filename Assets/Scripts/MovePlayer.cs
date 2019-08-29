using UnityEngine;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour, IDragHandler {

    public Transform Player;

    [SerializeField]
    private float speed = 15f;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate = 0.5f;
    public float nextFire = 0.0f;

    void Update() {

        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

    }


    public void OnDrag(PointerEventData eventData) {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        mousePos.x = mousePos.x > 2.4f ? 2.4f : mousePos.x;
        mousePos.x = mousePos.x < -2.4f ? -2.4f : mousePos.x;

        
        Player.position = Vector2.MoveTowards(Player.position, 
            new Vector2(mousePos.x, Player.position.y),
            speed * Time.deltaTime);
    }
    
}