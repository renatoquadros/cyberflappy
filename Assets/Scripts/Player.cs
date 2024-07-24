using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 1;
    private Rigidbody2D rig;
    public float rotationSpeed = 200f;
    public float maxUpwardAngle = 15f;
    public float maxDownwardAngle = -15f;

    private Animator animator;
    private bool isMoving;

    //public GameObject gameOver;

    private GameController gameController;// create a reference for object GameController

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Initiate the instance of GameController object
        rig = GetComponent<Rigidbody2D>();        
        
        animator = GetComponent<Animator>();
        animator.Play("Car_Idle");
        Debug.Log(isMoving);
      
    }

    // Update is called once per frame
    void Update()
    {
       MovPlayer();
       RotatePlayer();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(gameController != null){gameController.ShowGameOver();}// call method GameOver from GameController
    }

    void MovPlayer()
    {
        bool isMoving = false;
           //ao clicar no mouse adiciona velocidade no player
        if(Input.GetMouseButtonDown(0)){
            rig.velocity = Vector2.up*speed;
            isMoving = true;            
          
            //Debug.Log(isMoving);
        }
        
          animator.SetBool("isMoving", isMoving);
        
    }

    void RotatePlayer()
    {
        float targetAngle = 0f;

        // Se o jogador está se movendo para cima
        if (rig.velocity.y > 0.1f)
        {
            targetAngle = 10f; // Ângulo para cima
        }
        // Se o jogador está se movendo para baixo
        else if (rig.velocity.y < -0.1f)
        {
            targetAngle = -5f; // Ângulo para baixo
        }
        else if(rig.velocity.y < -1f)
        {
            targetAngle = -25f;
        }

        // Rotacionar suavemente em direção ao ângulo alvo
        float angle = Mathf.LerpAngle(transform.rotation.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    /*void RotatePlayer()
    {
        float targetAngle = 0f;

        // Se o jogador está se movendo para cima
        if (rig.velocity.y > 0.1f)
        {
            targetAngle = Mathf.Lerp(0, maxUpwardAngle, rig.velocity.y / speed);
        }
        // Se o jogador está se movendo para baixo
        else if (rig.velocity.y < -0.1f)
        {
            targetAngle = Mathf.Lerp(0, maxDownwardAngle, -rig.velocity.y / speed);
        }

        // Rotacionar suavemente em direção ao ângulo alvo
        float angle = Mathf.LerpAngle(transform.rotation.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }*/
}
