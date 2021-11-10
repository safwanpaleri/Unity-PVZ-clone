using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerScript : MonoBehaviour
{
    GameObject currenttarget;
    //[Range(0f, 3f)] [SerializeField] float speed = 1f;
    float currentspeed = 1f;

    private void Awake()
    {
        FindObjectOfType<LevelController>().IncreaseAttackers();
    }
    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().DecreaseNoOfAttackers();
    }

   
    void Update()
    {
       transform.Translate(Vector2.left * currentspeed * Time.deltaTime);
        updateAnimation();
    }

    private void updateAnimation()
    {
        if(!currenttarget)
        {
            GetComponent<Animator>().SetBool("isattacking", false);
        }    
    }

    public void SetMovementSpeed(float speed)
    {
        currentspeed = speed;
    }

    public void attackmode(GameObject otherobject)
    {
        GetComponent<Animator>().SetBool("isattacking", true);
        currenttarget = otherobject;
    }

    public void strikedefender(float damage)
    {
        if (!currenttarget) { return; }
        HealthScript health = currenttarget.GetComponent<HealthScript>();
        if (health)
        {
            health.DealDamage(damage);
        }
}
}
