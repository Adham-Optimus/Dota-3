using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissimilateScript : MonoBehaviour
{
    Animator animator;
    PlayerScript player;
    private int levelOfSpell;
    private float damageOfSpell;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<PlayerScript>();
        //animator.Play("Static");
        levelOfSpell = player.secondSpelllevel;
        switch (levelOfSpell)
        {
            case 1: damageOfSpell = 140; break;
            case 2: damageOfSpell = 220; break;
            case 3: damageOfSpell = 300; break;
            case 4: damageOfSpell = 380; break;
        }
        player.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        StartCoroutine(Dissimilate());
    }

    private IEnumerator Dissimilate()
    { 
        yield return new WaitForSeconds(2f);
        player.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        animator.SetBool("Dissimilate", true);
        Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, 6, 1 << 6 | 1 << 8);
        foreach (Collider2D coll2 in coll)
        {
            coll2.GetComponent<IDamagable>().TakeDamage(damageOfSpell, true);
        }
        Destroy(gameObject, 0.4f);
    }

    
}
