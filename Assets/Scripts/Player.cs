using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    public Bullet bullet;
    public GameObject bat;
    public GameObject gun;
    public GameObject Bullet;
    Animator animator;
    CharacterController controller;
    Rigidbody rigid;
    public int rotateSpeed;
    public bool correctGun = false;
    public int speed = 5;
    public int Hp;
    public int MaxHp;
    public bool isWalk;
    public bool isDie;
    public bool isAttackCheck = false;
    private void Start()
    {
        bat.SetActive(true);
        gun.SetActive(false);
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
        Rotation();
        
    }

 

    private void Move()
    {
        Vector3 move = new Vector3 (Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical")).normalized;
       if(Input.GetKey(KeyCode.W))
        {
            controller.Move(this.transform.forward * speed* Time.deltaTime);
            isWalk = true;
        }
       else if(Input.GetKey(KeyCode.S))
        {
            controller.Move(-this.transform.forward *speed * Time.deltaTime);
            isWalk= true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            controller.Move(-this.transform.right * speed * Time.deltaTime);
            isWalk = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            controller.Move(this.transform.right * speed * Time.deltaTime);
            isWalk = true;
        }
       else
        {
            isWalk = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            ChangeWeapon();
            Destroy(other.gameObject);
        }


    }


    void ChangeWeapon()
    {
        bat.SetActive(false);
        gun.SetActive(true);
        correctGun = true;
    }
    void Rotation()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if(plane.Raycast(cameraRay, out rayLength))
        {
            Vector3 lookDir = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(lookDir.x, transform.position.y, lookDir.z));
        }
    }

    void Attack()
    {
        if(Input.GetMouseButton(0))
        {
            if (!isAttackCheck && !correctGun)
            {
                animator.SetTrigger("isAttack");
                isAttackCheck = true;
                StartCoroutine("StopAttack");
            }
            else if (!isAttackCheck && correctGun)
            {
                animator.SetTrigger("isGun");
                isAttackCheck =true;
                StartCoroutine("Shot");
            }

        }
    }

   IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttackCheck =false;
    }

    IEnumerator Shot()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(Bullet, new Vector3(transform.position.x,transform.position.y + 0.8f,transform.position.z), this.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        isAttackCheck = false;
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
                animator.SetTrigger("isDie");
            }

        }
    }

    public IEnumerator SpeedPotion()
    {
        Debug.Log("스피드 업");
        speed = 8;
        yield return new WaitForSeconds(4);
        speed = 5;
        Debug.Log("효과 종료");
    }
    public void BulletPotion()
    {
        Debug.Log("총알 속도 증가");
        bullet.speed += 5;
    }

    public void HpPotion()
    {
        Debug.Log("피회복");
        Hp = MaxHp;
    }
}
