using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public int Damage = 1;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        
        
    }
    public enum CharacterType
    {
        Player,
        Enemy,
    }
    public CharacterType type;

    private void OnTriggerEnter(Collider other)
    {
        switch(type)
        {
            case CharacterType.Player:
                if (player.isAttackCheck)
                {
                    if (other.CompareTag("Enemy"))
                    {
                        enemy = other.gameObject.GetComponent<Enemy>();
                        player.isAttackCheck = false;
                        Debug.Log("A");
                        enemy.SetHp(Damage);
                    }
                }

                break;
            case CharacterType.Enemy:
                if(other.CompareTag("Player"))
                {
                    if (enemy.isAttack)
                    {
                        enemy.isAttack = false;
                        Debug.Log("B");
                        player.SetHp(Damage);
                    }
                }
                break;
        }
    }
}
