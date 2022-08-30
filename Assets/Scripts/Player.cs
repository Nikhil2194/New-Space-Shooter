using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    Vector2 rawInput;
    [SerializeField] float moveSpeed = 5f;
   [SerializeField] public float min_X, max_X, min_Y, max_Y;
    Shooter shooter;

 

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
     
    }

    void Update()
    {
        PlayerMove();
        OnFire();
    }

   

    private void PlayerMove()      // player movement
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += moveSpeed * Time.deltaTime;
            transform.position = temp;

            if (temp.y > max_Y)
                temp.y = max_Y;
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= moveSpeed * Time.deltaTime;
            transform.position = temp;

            if (temp.y < min_Y)
                temp.y = min_Y;
            transform.position = temp;
        }

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp;

            if (temp.x > max_X)
                temp.x = max_X;
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < min_X)
                temp.x = min_X;
            transform.position = temp;
        }
    }

   

    void OnFire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shooter.isFiring = true;
        }
        //if (shooter != null)
        //{
        //    shooter.isFiring = value.isPressed;
        //}
    }
}
