using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTMP;
    [SerializeField] private GameObject statManager;

    public float baseHealth = 50;
    public float currentHealth;
    public bool isDead = false;

    private StatManager statManagerScript;

    void Start()
    {
        //currentHealth = (baseHealth + statManagerScript);

        //Debug.Log(statManager.GetComponent<StatManager>().healthStatTotal);
    }

    void Update()
    {
        //if (currentHealth <= 0)
        //{
            //currentHealth = 0;
        //}

        //textTMP.text = currentHealth.ToString();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
