using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject car_player;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; 
        //car_player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    this.gameObject.SetActive(false);
        //    Time.timeScale = 1f; 
        //}

        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.SetActive(false);
            car_player.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
