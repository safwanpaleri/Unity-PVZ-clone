//Headers
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerScript : MonoBehaviour
{
    //Variables.
    //the target is assigned in a different script.
    GameObject currenttarget;
    float currentspeed = 1f;

    void Update()
    {
        //Set the attacker into motion.
       transform.Translate(Vector2.left * currentspeed * Time.deltaTime);
        updateAnimation();
    }

    //changing the animation
    private void updateAnimation()
    {
        if(!currenttarget)
        {
            GetComponent<Animator>().SetBool("isattacking", false);
        }    
    }

    //Setting up the speed.
    public void SetMovementSpeed(float speed)
    {
        currentspeed = speed;
    }

    //Setting up attacks
    public void attackmode(GameObject otherobject)
    {
        GetComponent<Animator>().SetBool("isattacking", true);
        currenttarget = otherobject;
    }

    //Damaging the target.
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
