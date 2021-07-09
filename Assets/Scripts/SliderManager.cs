using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    private Slider slider;
    public GameObject Player;
    public float factor = 20.0f;
    public Image Fill;
    private bool active;
    public Color low;
    public Color perfect;
    public Color high;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        active = Player.GetComponent<MovementController>().active;

        if ((Input.GetKey("e") || Input.GetButton("Fire2")) && active)
        {
            slider.value += 0.3f / factor * Time.deltaTime;
            if (slider.value < 0.3f)
            {
                Fill.color = Color.Lerp(Color.yellow, Color.green, 0.1f);
            }
            else if (slider.value > 0.3f && slider.value < 0.6f)
            {
                Fill.color = Color.Lerp(Color.green, Color.red, 0.1f);
            }
            else
            {
                Fill.color = Color.red;
            }

        }
        else if (Input.GetKeyUp("e") || Input.GetButtonUp("Fire2"))
        {
            Fill.color = Color.yellow;
            slider.value = 0f;
        }



    }
}
