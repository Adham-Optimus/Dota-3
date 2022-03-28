using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavnoScript : MonoBehaviour
{
    Vector3 playerTransform;
    private void Start()
    {
        Destroy(gameObject, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collision.GetComponent<PlayerScript>().TakeDamage(100);
            Destroy(gameObject);
        }
    }

    public void SetVector3(Vector3 vec)
    {
        playerTransform = vec;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform,5 * Time.deltaTime);
    }
}
