using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRangeX;
    [SerializeField] float attackRangeY;
    [SerializeField] private LayerMask enemyLayer;

    private StatManager statManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider[] hitEnemy = Physics.OverlapBox(attackPoint.position, new Vector3(attackRangeX, attackRangeY), Quaternion.identity, enemyLayer);

        foreach(Collider enemy in hitEnemy)
        {
            enemy.GetComponent<HealthManager>().TakeDamage(statManager.attackStatTotal);
        }
    }
}
