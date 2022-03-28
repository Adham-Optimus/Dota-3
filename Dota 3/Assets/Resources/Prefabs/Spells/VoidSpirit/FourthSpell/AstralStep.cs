using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralStep : MonoBehaviour
{
    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;
    PlayerScript player;
    Animator animator;
    private int levelOfSpell;
    private float damageOfSpell;
    void Start()
    {
        player = GetComponentInParent<PlayerScript>();
        Destroy(gameObject, 3f);
        levelOfSpell = player.fourthSpelllevel;
        switch (levelOfSpell)
        {
            case 1: damageOfSpell = 140;  break;
            case 2: damageOfSpell = 220;  break;
            case 3: damageOfSpell = 300;  break;
            case 4: damageOfSpell = 380;  break;
        }
        if (player.facingRight)
        {
            player.transform.position += new Vector3(6, 0);
        }
        else
        {
            transform.localScale *= -1;
            pointA *= -1;
            pointB *= -1;
            player.transform.position += new Vector3(-6, 0, 0);
        }
        Collider2D[] coll = Physics2D.OverlapAreaAll(transform.position + pointA, transform.position + pointB, 1 << 6 | 1 << 8);
        foreach(Collider2D _coll in coll)
        {
            _coll.GetComponent<IDamagable>().TakeDamage(damageOfSpell, true);
        }
    }

    private void OnDrawGizmos()
    {
        CustomDebug.DrawRectange(pointA, pointB);
    }
}
