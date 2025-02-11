using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class WeaponDamage : MonoBehaviour
{
    public float damage;
    public float addDamage = 7f;
    public GameObject itemCrown;
    public bool cheatMode = false; 

    BoxCollider triggerBox;
    EnemyAI enemy;
    BossAI bossAI;
    BossAII bossAII;

    private void Start()
    {
        triggerBox = GetComponent<BoxCollider>();
        enemy = GetComponent<EnemyAI>();
        bossAI = GetComponent<BossAI>();
        bossAII = GetComponent<BossAII>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            cheatMode = !cheatMode;
            Debug.Log("Cheat mode: " + (cheatMode ? "ON" : "OFF"));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float totalDamage = damage;

        if (cheatMode)
        {
            totalDamage = float.MaxValue; // One hit
        }
        else if (itemCrown != null && itemCrown.activeInHierarchy)
        {
            totalDamage += addDamage;
        }

        var enemy = other.gameObject.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            Debug.Log("Enemy Get Hit");
            enemy.TakeDamage(totalDamage);
            return;
        }

        var bird = other.gameObject.GetComponent<BossAII>();
        if (bird != null)
        {
            Debug.Log("Bird Get Hit");
            bird.TakeDamage(totalDamage);
            return;
        }
        else
        {
            var boss = other.gameObject.GetComponent<BossAI>();
            if (boss != null)
            {
                Debug.Log("Boss get Hit");
                boss.TakeDamage(totalDamage);
                return;
            }
        }
    }
}
