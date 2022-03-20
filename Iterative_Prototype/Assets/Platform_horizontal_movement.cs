using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_horizontal_movement : MonoBehaviour
{
    public GameObject Player;
    public float speed = 2.5f;
    private float originalX;
    // Start is called before the first frame update
    void Start()
    {
        originalX = transform.position.x;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 3) + originalX, transform.position.y, transform.position.z);
    }
   
}
