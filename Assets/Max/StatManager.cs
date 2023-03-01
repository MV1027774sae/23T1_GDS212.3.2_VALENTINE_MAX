using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatManager : MonoBehaviour
{
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

    [SerializeField] private TextMeshProUGUI healthUI;
    
    void Start()
    {
        RandomiseStats();
    }

    void Update()
    {
        
    }

    public void RandomiseStats()
    {
        healthStat = Random.Range(minimumPoolRange, maximumPoolRange);
        attackStat = Random.Range(minimumPoolRange, maximumPoolRange);
        attackSpeedStat = Random.Range(minimumPoolRange, maximumPoolRange);

        float healthStatTotal = baseHealthStat + healthStat * healthModifier;
        float attackStatTotal = baseAttackStat + attackStat * attackModifier;
        float attackSpeedStatTotal = baseAttackSpeedStat + attackSpeedStat * attackSpeedModifier;


        Debug.Log("Health stat = " + Mathf.Round(healthStatTotal));
        Debug.Log("Attack stat = " + Mathf.Round(attackStatTotal));
        Debug.Log("Attack speed stat = " + Mathf.Round(attackSpeedStatTotal));
    }
}
