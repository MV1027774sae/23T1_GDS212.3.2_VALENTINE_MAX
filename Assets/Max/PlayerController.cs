using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRangeX;
    [SerializeField] float attackRangeY;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private ParticleSystem attackEffect;

    [SerializeField] private StatManager statManager;

    private CharacterController controls;
    private StarterAssetsInputs inputs;


    void Awake()
    {
        controls = GetComponent<CharacterController>();
        inputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //{
            //Attack();
            //Debug.Log("Attack");
        //}
    }

    public void Attack()
    {
        Collider[] hitEnemy = Physics.OverlapBox(attackPoint.position, new Vector3(attackRangeX, attackRangeY), Quaternion.identity, enemyLayer);

        foreach(Collider enemy in hitEnemy)
        {
            enemy.GetComponent<HealthManager>().TakeDamage(statManager.attackStatTotal);
        }

        //GameObject spark = Instantiate(sparkPrefab);
        //spark.transform.position = sparkPrefab.transform.position;

        //ParticleSystem attackSparkParticles = Instantiate(sparkParticles);
        //attackSparkParticles.transform.position = spark
        attackEffect.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.position, new Vector3 (attackRangeX, 1, attackRangeY));
    }
}
