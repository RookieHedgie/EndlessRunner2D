using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    public GameObject effect;
    public GameObject explosionSound;
    private Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void Update()
    {
        //obstacle will move left
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            camAnim.SetTrigger("ouch");
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);

            other.GetComponent<Player>().health -= damage; //decrease the player's health
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
}
