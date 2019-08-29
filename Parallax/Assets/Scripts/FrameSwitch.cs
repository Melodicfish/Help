using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameSwitch : MonoBehaviour
{

    public GameObject frame1;
    public GameObject frame2;
    public Transform player;
    private bool frame1Active;
    private ParallaxCamera parallax;
    public Image screenFade;
    public Parallax frame1Parallax;
    public Parallax frame2Parallax;
    public ParallaxCamera parallaxCamera;
    public Collider2D barrier;
    public Transform posA;
    public Transform posB;

    private void Awake()
    {
        frame1Parallax = frame1.GetComponent<Parallax>();
        frame2Parallax = frame2.GetComponent<Parallax>();

        frame1Parallax.enabled = false;
        frame2Parallax.enabled = false;
    }


    private void Start()
    {
        

        screenFade.canvasRenderer.SetAlpha(0.0f);
        if (frame1.activeInHierarchy)
        {
            frame1Parallax.enabled = true;
        }

        if (frame2.activeInHierarchy)
        {
            frame2Parallax.enabled = true;
        }

    }

  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // fadeIn();
        //StartCoroutine(setActive());
        frame1Parallax.enabled = false;
        frame2Parallax.enabled = false;
    }

    
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Vector2.Distance(posA.transform.position, collision.transform.position) < Vector2.Distance(posB.transform.position, collision.transform.position))
            {
                frame1Parallax.enabled = true;  
            }
            if (Vector2.Distance(posA.transform.position, collision.transform.position) > Vector2.Distance(posB.transform.position, collision.transform.position))
            {
                frame2Parallax.enabled = true;
            }
        }
        /*
        if(transform.position.x>= player.transform.position.x)
        {
            
            frame1.SetActive(true);
            frame2.SetActive(false);
            frame1Parallax.enabled = true;
            frame2Parallax.enabled = false;

        }
        if (transform.position.x < player.transform.position.x)
        {
           
            frame1.SetActive(false);
            frame2.SetActive(true);
            
            frame1Parallax.enabled = false;
            StartCoroutine(setActive2());
        }
        fadeOut();*/
    }



    
    void fadeIn()
    {
        screenFade.canvasRenderer.SetAlpha(0.0f);
        screenFade.CrossFadeAlpha(1, .1f, false);
    }

    void fadeOut()
    {
        screenFade.canvasRenderer.SetAlpha(1.0f);
        screenFade.CrossFadeAlpha(0, 1, false);

    }

    IEnumerator setActive()
    {
        yield return new WaitForSeconds(.2f);
       // frame1.SetActive(true);
        //frame2.SetActive(true);

    }
    IEnumerator setActive2()
    {
        yield return new WaitForSeconds(2f);
        // frame1.SetActive(true);
        //frame2.SetActive(true);
        frame2Parallax.enabled = true;
    }

}
