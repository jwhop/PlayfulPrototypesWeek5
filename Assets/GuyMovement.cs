using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 camPos1, camPos2;
    [SerializeField] GameObject cam, pizza, microWaveText, cheeseText, microwaveTimer, OJText;
    private bool visitedFridge, takenPizza;
    // Start is called before the first frame update
    void Start()
    {
        visitedFridge = false;
        takenPizza = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!(transform.position.x <= -15f && Input.GetAxis("Horizontal") < 0) && 
            !(transform.position.x >= 7f && Input.GetAxis("Horizontal") > 0))
                transform.Translate(Input.GetAxis("Horizontal") * transform.right * speed);
        if(transform.position.x < -7.5f)
        {
            cam.transform.position = camPos2;
            visitedFridge = true;
            if(Input.GetAxis("Fire2") > 0 && !takenPizza)
            {
                takenPizza = true;
                microWaveText.SetActive(true);
                pizza.SetActive(true);
            }
        }
        else
        {
            cam.transform.position = camPos1;
            if(transform.position.x <-2.5f && Input.GetAxis("Fire1") > 0)
            {
                pizza.SetActive(false);
                microWaveText.SetActive(false);
                microwaveTimer.SetActive(true);
                microwaveTimer.GetComponent<timer>().StartTimer = true;
                cheeseText.SetActive(true);
                OJText.SetActive(true);

            }
        }
        
        print(Input.GetAxis("Fire2"));
    }
}
