using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CharacterAnimation enemyAnim;
    private Rigidbody mBody;
    public float speed = 1.8f;
    private Transform playerTarget;
    public float attack_Distance = 1.3f;
    public float chase_Player_After_Attack=1f;
    private float current_Attack_Time;
    private float default_Attack_Time=2f;
    private bool followPlayer, attackPlayer;
     void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        mBody = GetComponentInChildren<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    void Start()
    {
        followPlayer = true;
        current_Attack_Time = default_Attack_Time;
    }

    // Update is called once per frame
    void Update()
    {
        
        Attack();
    }
     void FixedUpdate()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        if (!followPlayer)
            return;

        if(Vector3.Distance(transform.position, playerTarget.position) > attack_Distance)
        {
            transform.LookAt(playerTarget);
            mBody.linearVelocity = transform.forward * speed;
            if (mBody.linearVelocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }else if(Vector3.Distance(transform.position,playerTarget.position)<=attack_Distance)
        {
            mBody.linearVelocity = Vector3.zero;
            enemyAnim.Walk(false);
            followPlayer = false;
            attackPlayer = true;
        }

    }
    void Attack()
    {
        if (!attackPlayer)
            return;
        current_Attack_Time += Time.deltaTime;
        if(current_Attack_Time > default_Attack_Time)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            current_Attack_Time = 0f;
        }
        if(Vector3.Distance(transform.transform.position, playerTarget.position) > attack_Distance+chase_Player_After_Attack) { 
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
