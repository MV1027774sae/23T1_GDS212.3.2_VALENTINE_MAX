using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRangeX;
    [SerializeField] float attackRangeY;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private ParticleSystem attackEffect;

    [SerializeField] private float minimumPoolRange = 0;
    [SerializeField] private float maximumPoolRange = 11;

    private float baseHealthStat = 5;
    private float baseAttackStat = 5;
    private float baseAttackSpeedStat = 5;

    //private float totalStatPool = 10;
    private float healthStat;
    private float attackStat;
    private float attackSpeedStat;

    [SerializeField] private float healthModifier;
    [SerializeField] private float attackModifier;
    [SerializeField] private float attackSpeedModifier;

    public float healthStatTotal;
    public float attackStatTotal;
    public float attackSpeedStatTotal;

    private float attackRange = 5f;

    //[SerializeField] private TextMeshProUGUI healthUI;

    [SerializeField] private TextMeshProUGUI textTMP;
    [SerializeField] private TextMeshProUGUI textTMPTwo;
    //[SerializeField] private GameObject statManager;

    public float baseHealth = 50;
    public float currentHealth;
    public bool isDead = false;

    public float lookRadius = 20f;

    Transform target;
    NavMeshAgent agent;

    private float damage;
    private float nextAttackTime;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        RandomiseEnemyStats();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene(1);
        }

        if (Time.time >= nextAttackTime)
        {
            if (distance <= attackRange)
            {
                EnemyAttack();
                nextAttackTime = Time.time + 1.5f;
            }
        }

        textTMP.text = "HP = " + Mathf.Round(currentHealth).ToString();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }

    public void RandomiseEnemyStats()
    {
        healthStat = Random.Range(minimumPoolRange, maximumPoolRange);
        attackStat = Random.Range(minimumPoolRange, maximumPoolRange);
        attackSpeedStat = Random.Range(minimumPoolRange, maximumPoolRange);

        float healthStatTotal = baseHealthStat + healthStat * healthModifier;
        float attackStatTotal = baseAttackStat + attackStat * attackModifier;
        float attackSpeedStatTotal = baseAttackSpeedStat + attackSpeedStat * attackSpeedModifier;

        currentHealth = (baseHealth + healthStatTotal);
        damage = attackStatTotal;
        textTMPTwo.text = "Atk Pwr = " + Mathf.Round(damage).ToString();

        Debug.Log("Enemy Health stat = " + Mathf.Round(healthStatTotal));
        Debug.Log("Enemy Attack stat = " + Mathf.Round(attackStatTotal));
        Debug.Log("Enemy Attack speed stat = " + Mathf.Round(attackSpeedStatTotal));
    }
    public void TakeEnemyDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
    }

    public void EnemyAttack()
    {
        Collider[] hitEnemy = Physics.OverlapBox(attackPoint.position, new Vector3(attackRangeX, 1, attackRangeY), Quaternion.identity, enemyLayer);

        foreach (Collider collider in hitEnemy)
        {
            collider.GetComponent<StatManager>().TakeDamage(damage);
        }
        attackEffect.Play();
    }
}
