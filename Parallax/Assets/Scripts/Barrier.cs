using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public FrameSwitch switcher;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.GetComponent<Player>().canMove = false;
            if (Vector2.Distance(posA.transform.position, collision.transform.position) < Vector2.Distance(posB.transform.position, collision.transform.position))
            {
                collision.GetComponent<Player>().targetPos = posB;
                switcher.frame2.SetActive(true);
                switcher.frame1.SetActive(false);


            }
            if(Vector2.Distance(posB.transform.position, collision.transform.position) < Vector2.Distance(posA.transform.position, collision.transform.position))
            {
                collision.GetComponent<Player>().targetPos = posA;
                switcher.frame1.SetActive(true);
                switcher.frame2.SetActive(false);
            }
                
            
        }
    }
}
