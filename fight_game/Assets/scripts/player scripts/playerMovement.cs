using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class playerMovement : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;
    public float Walk_speed = 2f;
    public float z_speed = 1.5f;
    private float rotation_Y = -90f; 
    private float rotation_Speed = -15f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update(){
        RotatePlayer();
        AnimatePlayerWalk();
    }
    void FixedUpdate()
    { 
        DetectMovement();
    }

    void DetectMovement()
    {
        myBody.linearVelocity = new Vector3(
            Input.GetAxis(Axis.HORIZONTAL_AXIS) * (-Walk_speed),
            myBody.linearVelocity.y,
            Input.GetAxis(Axis.VERTICAL_AXIS) * (-z_speed));
    }
    void RotatePlayer(){
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0){
            transform.rotation = Quaternion.Euler(0f, (rotation_Y), 0f);
        }
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0){
            transform.rotation = Quaternion.Euler(0f,Mathf.Abs(rotation_Y), 0f);

        }
        
            
        }// rotation
        void AnimatePlayerWalk()
        {
            if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)!=0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS)!=0)
            {
                player_Anim.Walk(true);
            }
            else{
                player_Anim.Walk(false);
            }
        }//animate player walk

    }//class



