using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Item;
    float checkPlayer;
    public GameObject target;
    NavMeshAgent agent;
    Animator animator;
    public int Hp = 3;
    public bool isDie = false;
    public bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {

        
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.stoppingDistance = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDie)
        {
            Move();
        }
        
    }

    private void Move()
    {
        if (Vector3.Distance(target.transform.position, this.gameObject.transform.position) <= 5)
        {
            agent.isStopped = false;
            transform.LookAt(target.transform.position);
            agent.destination = target.transform.position;
            animator.SetBool("isMove", true);
            if (Vector3.Distance(target.transform.position, this.transform.position) <= 1.5f)
            {

                if(isDie)
                {
                    StartCoroutine("Attack");
                }
                animator.SetBool("isMove", false);

            }
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("isMove", false);
        }
    }
    
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = true;
        animator.SetTrigger("isAttack");
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
        
    }
    public void SetHp(int damage)
    {
        if (!isDie)
        {
            Hp -= damage;
            if (Hp <= 0)
            {
                Hp = 0;
                isDie = true;
                animator.SetTrigger("isDie");
                Instantiate(Item, transform.position, Quaternion.identity);
                StartCoroutine("Delete");
            }

        }
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
