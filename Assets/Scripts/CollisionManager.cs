using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollisionManager : MonoBehaviour
{
    public Text Score;
    public int score = 0;
    private bool isTriggered = false;
    public GameObject sound;


    private void OnTriggerEnter(Collider obj)
    {       
        if(obj.gameObject.name == "Ball")
        {   
            if (!isTriggered) { score += 5; isTriggered = true; Score.text = "Score: " + score; sound.GetComponent<AudioSource>().Play();}
        
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        isTriggered = false;
    }

}
