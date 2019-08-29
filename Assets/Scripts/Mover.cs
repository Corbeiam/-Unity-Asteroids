using UnityEngine;

public class Mover : MonoBehaviour
{

    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.up * speed;
    }


}
