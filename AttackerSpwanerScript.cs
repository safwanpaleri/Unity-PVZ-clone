//Headers.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpwanerScript : MonoBehaviour
{
    //Variables.
    [Header("SPAWNING")]
    bool spwan = true;
    [SerializeField] float minDelay = 1f;
    [SerializeField] float maxDelay = 5f;

    [Header("Attacker")]
    //There are different types of attackers.
    //all the types are saved in a single array.
    [SerializeField] AttackerScript[] Attacker;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        //While the spawn still continues.
        if (spwan)
        {  
            //Spawn the enemy after a delay.
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            spawnAttacker();
        }
    }

    //Function to stop the spwan
    public void StopSpawn()
    {
        spwan = false;
       
    }
    
    //Function responsible for spawning the attacker.
    private void spawnAttacker()
    {
        //Select a random attacker from the array of attackers.
        int index = Random.Range(0, Attacker.Length);
        spawnindex(LizardAttacker[index]);
    }

    //Code for spawning the attacker.
    private void spawnindex(AttackerScript newAttacker)
    {
        AttackerScript newAttcker = Instantiate (newAttacker, transform.position, Quaternion.identity) as AttackerScript;
        newAttcker.transform.parent = transform;
    }

    //Change the timing between the spwans according to difficulty.
    public void updatedelay(float diff)
    {
        if(diff == 0 )
        {
            minDelay = 8f;
            maxDelay = 12f;
        }
        else if(diff == 1)
        {
            minDelay = 5f;
            maxDelay = 8f;
        }
        else if(diff == 2)
        {
            minDelay = 3f;
            maxDelay = 5f;
        }
        else if (diff ==3)
        {
            minDelay = 1f;
            maxDelay = 2f;
        }
    }    

}
