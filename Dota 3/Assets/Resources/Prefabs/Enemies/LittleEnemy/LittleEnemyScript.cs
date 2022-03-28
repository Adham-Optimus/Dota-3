using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class LittleEnemyScript : MonoBehaviour
{
    Collider2D coll;
    [SerializeField] Transform target;
    NavMeshAgent agent;
    public float health;
    public float maxHealth;
    public float armor = 3;
    private float magicResistance = 0.01f;

    private bool canShoot = true;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false; 
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= (damage - (damage * ((armor * 0.06f) / ((armor * 0.06f) + 1))));
        if (health < 0) GiveXpToHero();
        GetComponentInChildren<Image>().fillAmount = health / maxHealth;
    }

    public void TakeDamage(float damage, bool magicDamage)
    {
        health -= (damage - (damage * magicResistance));
        if (health < 0) GiveXpToHero();
        GetComponentInChildren<Image>().fillAmount = health / maxHealth;
    }

    private void FixedUpdate()
    {
        if(coll != null)
        {
            agent.SetDestination(coll.transform.position);

        }
        if (canShoot)
        {
            //StartCoroutine(Shoot());
        }
    }



    private IEnumerator Shoot()
    {
        coll = Physics2D.OverlapCircle(transform.position, 4, 1 << 3);
        if (coll != null)
        {
            canShoot = false;
            yield return new WaitForSeconds(1f);
            GameObject gavno = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/LittleEnemy/Gavno"), transform.position + new Vector3(1, 1, 0), Quaternion.identity, transform);
            gavno.GetComponent<GavnoScript>().SetVector3(coll.transform.position);
            canShoot = true;
        }
        else canShoot = true;
        
    }

    private void GiveXpToHero()
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, 6, 1 << 3);
        foreach (Collider2D coll2 in coll)
        {
            coll2.GetComponent<PlayerScript>().XPInstaller(200);
            coll2.GetComponent<PlayerScript>().moneys += 100;
        }

        Destroy(gameObject);
    }
}
