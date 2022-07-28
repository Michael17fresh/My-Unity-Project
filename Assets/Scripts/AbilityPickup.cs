using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    public AbilityTypes abilityTypes;
    PlayerControls player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ActivateAbility();
            Destroy(gameObject);
        }
    }
    private void ActivateAbility()
    {
        // stacking = turn off  all abilities
        if(!player.stackAbilities)

        {
            foreach (GameObject ability in player.abilities)
            {
                ability.SetActive(false);
            }
        }
        //Turn on ability
        player.abilities[abilityTypes.GetHashCode()].SetActive(true);

    }
}
