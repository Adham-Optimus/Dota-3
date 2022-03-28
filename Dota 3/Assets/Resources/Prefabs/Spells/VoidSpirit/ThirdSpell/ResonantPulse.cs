using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResonantPulse : MonoBehaviour
{
    [SerializeField]private float timer = 1;
    PlayerScript player;
    Animator animator;
    private int levelOfSpell;
    private float damageOfSpell;
    void Start()
    {
        transform.localScale = new Vector2(6, 6);
        animator = GetComponent<Animator>();
        animator.Play("ResonantAnim");
        player = GetComponentInParent<PlayerScript>();
        levelOfSpell = player.thirdSpelllevel;
        switch (levelOfSpell)
        {
            case 1: damageOfSpell = 140; timer = 8; break;
            case 2: damageOfSpell = 220; timer = 9; break;
            case 3: damageOfSpell = 300; timer = 10; break;
            case 4: damageOfSpell = 380; timer = 11; break;
        }
        player.ArmorInstaller(30);
        Collider2D[] _coll = Physics2D.OverlapCircleAll(transform.position, 6, 1 << 6 | 1 << 8);

        foreach (Collider2D coll in _coll)
        {
            coll.GetComponent<IDamagable>().TakeDamage(damageOfSpell, true);
        }
        /*{
            if (coll.tag == "Enemy")
            {
                coll.GetComponent<CreepScript>().TakeDamage(damageOfSpell, true);
            }
            else if (coll.GetComponent<PlayerScript>())
            {
                Debug.Log("here");
                coll.GetComponent<PlayerScript>().TakeDamage(damageOfSpell, true);
            }
        }*/

    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) { Destroy(gameObject); }
    }
}
