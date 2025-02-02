using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Potion
    {
        speed,
        bullet,
        hp,
    }
    public Potion potion;
    public int potionData;
    // Start is called before the first frame update
    private void Awake()
    {
        potionData = Random.Range(1, 4);
        switch (potionData)
        {
            case 1:
                potion = Potion.speed;
                break;
            case 2:
                potion = Potion.bullet;
                break;
            case 3:
                potion = Potion.hp;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Player player = other.gameObject.GetComponent<Player>();
            switch (potion)
            {
                case Potion.speed:
                    player.StartCoroutine("SpeedPotion");
                    break;
                case Potion.bullet:
                    player.BulletPotion();
                    break;
                case Potion.hp:
                    player.HpPotion();
                    break;

            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
