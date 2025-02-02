using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float time  = 0;
    public int Damage = 2;
    Enemy enemy;
    Player player;
    Rigidbody rigid;
    public float speed = 10;
    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = other.gameObject.GetComponent<Enemy>();
            enemy.SetHp(Damage);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
