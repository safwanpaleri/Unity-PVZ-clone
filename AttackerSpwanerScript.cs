using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpwanerScript : MonoBehaviour
{
    [Header("SPAWNING")]
    bool spwan = true;
    [SerializeField] float minDelay = 1f;
    [SerializeField] float maxDelay = 5f;

    [Header("Attacker")]
    [SerializeField] AttackerScript[] LizardAttacker;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (spwan)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            spawnAttacker();
        }
    }

    public void StopSpawn()
    {
        spwan = false;
       
    }
    private void spawnAttacker()
    {
            int index = Random.Range(0, LizardAttacker.Length);
            spawnindex(LizardAttacker[index]);
    }

    private void spawnindex(AttackerScript newAttacker)
    {
        AttackerScript newAttcker = Instantiate (newAttacker, transform.position, Quaternion.identity) as AttackerScript;
        newAttcker.transform.parent = transform;
    }

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
