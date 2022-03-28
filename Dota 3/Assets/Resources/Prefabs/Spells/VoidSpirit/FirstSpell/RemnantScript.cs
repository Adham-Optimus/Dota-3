using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemnantScript : MonoBehaviour
{
    PlayerScript player;
    private int levelOfSpell;
    private float seconds;
    void Start()
    {
        Destroy(transform.parent.gameObject, 8);
        player = transform.parent.GetComponentInParent<PlayerScript>();
        levelOfSpell = player.firstSpelllevel;
        switch (levelOfSpell)
        {
            case 1: seconds = 2; break;
            case 2: seconds = 2.5f; transform.localScale = new Vector2(1.9f, 2); break;
            case 3: seconds = 3;    transform.localScale = new Vector2(2.1f, 2); break;
            case 4: seconds = 3.5f; transform.localScale = new Vector2(2.3f, 2); break;
        }
        transform.parent.parent = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log(seconds);
            if (player.facingRight) collision.transform.position += new Vector3(-0.1f, 0, 0) * Time.deltaTime;
            else collision.transform.position -= new Vector3(-0.1f, 0, 0) * Time.deltaTime;
            StartCoroutine(RemnantSkill());
        }
    }

    private IEnumerator RemnantSkill()
    {
        
        yield return new WaitForSeconds(seconds);
        Destroy(transform.parent.gameObject);
    }

}
