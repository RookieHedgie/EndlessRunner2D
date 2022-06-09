using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    [Header ("Inputs")] //Inputs Header
    public float Yincrement;
    public float speed;
    public int health = 3;
    [Space] //Space between min-maxHeight and other floats
    public float maxHeight;
    public float minHeight;
    [Space]
    public GameObject effect;
    public Text healthDisplay;
    public GameObject gameOver;
    public GameObject upDownSound;
    public Animator camAnim;

    private Vector3 fp; //first touch pos
    private Vector3 lp; //last touch pos
    private float dragDistance; //min distance for a swipe


    private void Update()
    {
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //Up and Down Arrow Controls
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight) 
        {
            //increment y if pressed up arrow and less than maxHeight
            camAnim.SetTrigger("shake");
            Instantiate(upDownSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement); 
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight) 
        {
            //decrease y if pressed up arrow and more than minHeight
            camAnim.SetTrigger("shake");
            Instantiate(upDownSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement); 
        }


        //W and S Controls
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight) 
        {
            //increment y if pressed W key and less than maxHeight
            camAnim.SetTrigger("shake");
            Instantiate(upDownSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement); 
        }
        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight) 
        {
            //decrease y if pressed S key and more than minHeight
            camAnim.SetTrigger("shake");
            Instantiate(upDownSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement); 
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if ((lp.y > fp.y) && transform.position.y < maxHeight)
                    {
                        //increment y if pressed W key and less than maxHeight
                        camAnim.SetTrigger("shake");
                        Instantiate(upDownSound, transform.position, Quaternion.identity);
                        Instantiate(effect, transform.position, Quaternion.identity);
                        targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
                    }
                    else
                    {
                        if (transform.position.y > minHeight)
                        {
                            camAnim.SetTrigger("shake");
                            Instantiate(upDownSound, transform.position, Quaternion.identity);
                            Instantiate(effect, transform.position, Quaternion.identity);
                            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
                        }
                    }
                }
            }
        }
    }        
}
