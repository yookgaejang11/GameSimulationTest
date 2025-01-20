using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    Animator animator;
    CharacterController controller;
    Rigidbody rigid;
    public int speed = 5;
    public int Hp;
    public bool isWalk;
    public bool isDie;
    public bool isAttackCheck = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isWalk)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
        Attack();
        Move();
    }

    private void Move()
    {
        Vector3 move = new Vector3 (Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical")).normalized;
       if(Input.GetKey(KeyCode.W))
        {
            controller.Move(move * speed* Time.deltaTime);
            isWalk = true;
        }
       else if(Input.GetKey(KeyCode.S))
        {
            controller.Move(move *speed * Time.deltaTime);
            isWalk= true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            controller.Move(move * speed * Time.deltaTime);
            isWalk = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            controller.Move(move * speed * Time.deltaTime);
            isWalk = true;
        }
       else
        {
            isWalk = false;
        }


    }

    void Attack()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetTrigger("isAttack");
        }
    }

    public void SetHp(int Damage)
    {
        if (!isDie)
        {
            Hp -= Damage;
            if (Hp <= 0)
            {
                Hp = 0;
                isDie = true;
            }

        }
    }
}
