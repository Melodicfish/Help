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
  
    public ParallaxCamera parallaxCamera;




    private void Start()
    {
        
        screenFade.canvasRenderer.SetAlpha(0.0f);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        fadeIn();
        StartCoroutine(setActive());
        
    }

    
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(transform.position.x>= player.transform.position.x)
        {
            
            frame1.SetActive(true);
            frame2.SetActive(false);
           
          
        }
        if (transform.position.x < player.transform.position.x)
        {
           
            frame1.SetActive(false);
            frame2.SetActive(true);
           

        }
        fadeOut();
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
        frame1.SetActive(true);
        frame2.SetActive(true);

    }
    
    
}
