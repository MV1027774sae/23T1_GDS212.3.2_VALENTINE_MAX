using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRangeX;
    [SerializeField] float attackRangeY;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private ParticleSystem attackEffect;

    [SerializeField] private StatManager statManager;

    [SerializeField] private EnemyController enemyController;

    private CharacterController controls;
    private StarterAssetsInputs inputs;

    [SerializeField] private float minimumPoolRange = 0;
    [SerializeField] private float maximumPoolRange = 11;

    private float baseAttackStat = 5;
    private float baseAttackSpeedStat = 5;

    private float attackStat;
    private float attackSpeedStat;

    [SerializeField] private float attackModifier;
    [SerializeField] private float attackSpeedModifier;

    public float attackStatTotal;
    public float attackSpeedStatTotal;

    private float damage;

    [SerializeField] private TextMeshProUGUI textTMPTwo;

    void Awake()
    {
        controls = GetComponent<CharacterController>();
        inputs = GetComponent<StarterAssetsInputs>();

        RandomiseAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
        //{
            //Attack();
            //Debug.Log("Attack");
        //}
    }

    public void RandomiseAttack()
    {
        attackStat = Random.Range(minimumPoolRange, maximumPoolRange);
        attackSpeedStat = Random.Range(minimumPoolRange, maximumPoolRange);

        float attackStatTotal = baseAttackStat + attackStat * attackModifier;
        float attackSpeedStatTotal = baseAttackSpeedStat + attackSpeedStat * attackSpeedModifier;

        damage = attackStatTotal;
        textTMPTwo.text = "Atk Power = " + Mathf.Round(damage).ToString();
    }

    public void Attack()
    {
        Collider[] hitEnemy = Physics.OverlapBox(attackPoint.position, new Vector3(attackRangeX, 1, attackRangeY), Quaternion.identity, enemyLayer);

        foreach(Collider collider in hitEnemy)
        {
                collider.GetComponent<EnemyController>().TakeEnemyDamage(damage);
        }
        attackEffect.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.position, new Vector3 (attackRangeX, 1, attackRangeY));
    }
}
