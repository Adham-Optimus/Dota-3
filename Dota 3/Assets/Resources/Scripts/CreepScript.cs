using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreepScript : MonoBehaviour, IDamagable
{
    [Header("OptionsForFlyingObject")]
    [SerializeField] Sprite flyingObjectsprite;
    [SerializeField] float flyingObjectSpeed;
    [SerializeField] float damage;

    [Header("Properties of creep")]
    public float attackRange;
    public bool isRange;
    NavMeshAgent agent;
    public float health;
    public float maxHealth;
    public float armor = 3;
    private float magicResistance = 0.1f;

    [SerializeField] bool canAttack = true;
    private bool isMoving = true;
    private bool forestCreep;
    [SerializeField] private bool isRadiant;
    private ushort againstSide;
    private Vector3 firstPos;
    private Vector3 secondPos;
    private bool goSecondPos;
    private int radiusOfDetection = 10;
    public enum Creep
    {
        ÑreepSwordsman = 0,
        RangedCreep = 1,
        SmallCreep = 2,
        MediumCreep = 3,
        BigCreep = 4,
        Roshan = 5
    }
    public Creep creep = Creep.ÑreepSwordsman;

    private void Start()
    {
        switch ((int)creep)
        {
            case 0:damage = 20;maxHealth = 350; armor = 2; isRange = false; break;
            case 1:damage = 30;maxHealth = 200; armor = 1; isRange = true; break;
            case 2:damage = 30;maxHealth = 250; armor = 2; isRange = false; break;
            case 3:damage = 50;maxHealth = 400; armor = 2; isRange = false; break;
            case 4:damage = 80;maxHealth = 800; armor = 5; magicResistance = 0.3f; isRange = false; break;
            case 5:damage = 200; maxHealth = 12000; armor = 15; magicResistance = 0.5f; isRange = false; break;
        }
        if (!isRange) attackRange = 2;
        else if(isRange) attackRange = 5;
        if ((int)creep > 1) forestCreep = true;
        else forestCreep = false;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        health = maxHealth;
        if (!forestCreep)
        {
            if (isRadiant) againstSide = 256;
            else if (!isRadiant) againstSide = 128;
        }
        if (forestCreep)
        {
            firstPos = GetComponent<CreepSpawner>().firstPos;
        }
    }
    public void TakeDamage(float damage, bool isMagic)
    {
        if (isMagic)
        {
            health -= (damage - (damage * magicResistance));
            if (health < 0) GiveXpToHero();
            GetComponentInChildren<Image>().fillAmount = health / maxHealth;
        }
        else
        {
            health -= (damage - (damage * ((armor * 0.06f) / ((armor * 0.06f) + 1))));
            if (health < 0) GiveXpToHero();
            GetComponentInChildren<Image>().fillAmount = health / maxHealth;
        }

    }

    private void Update()
    {
        if (canAttack)
        {
            StartCoroutine(Attack());
        }
        if (!forestCreep && !agent.isStopped)
        {
            if (!goSecondPos) 
            { 
                agent.SetDestination(firstPos);
                if (transform.position.x >= firstPos.x && isRadiant && transform.position.y >= firstPos.y || transform.position == firstPos) goSecondPos = true;
                else if (transform.position.y <= firstPos.y && !isRadiant && transform.position.x <= firstPos.x || transform.position == firstPos) goSecondPos = true;
            } 
            else if (goSecondPos) agent.SetDestination(secondPos);
        }
        else if (forestCreep && !agent.isStopped)
        {
            MoveToSpawn();
        }
    }

    private IEnumerator Attack()
    {
        Collider2D coll = null;
        if(Physics2D.OverlapCircle(transform.position, radiusOfDetection, againstSide))
        {
            if (!forestCreep) { coll = Physics2D.OverlapCircle(transform.position, attackRange, againstSide); }
            else if (forestCreep) { coll = Physics2D.OverlapCircle(transform.position, attackRange, 1 << 8 | 1 << 7); }
        }
        if (coll != null)
        {
            agent.isStopped = true;
            canAttack = false;
            yield return new WaitForSeconds(1f);
            if(isRange)
            {
                GameObject flyingObject = Instantiate(Resources.Load<GameObject>("Prefabs/Other/FlyingObject"), transform);
                if(coll!=null)flyingObject.GetComponent<FlyingObjectScript>().FlyingObjectInstaller(damage, coll.transform, flyingObjectSpeed, flyingObjectsprite, false);
            }
            else if (!isRange)
            {
                if(coll != null)
                    coll.GetComponent<IDamagable>().TakeDamage(damage, false);
            }
            canAttack = true;
        }
        else if (coll == null)
        {
            agent.isStopped = false;
        }
    }


    private void GiveXpToHero()
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, 6, 1 << 7);
        foreach (Collider2D coll2 in coll)
        {
            if(coll2.tag == "Player")
            {
                coll2.GetComponent<PlayerScript>().XPInstaller(100);
                coll2.GetComponent<PlayerScript>().moneys += 10;
            }
        }
        Destroy(gameObject);
    }
    public void MoveToSpawn()
    {
        agent.SetDestination(firstPos);
        if (transform.position == firstPos) isMoving = false;
    }

    public void InstallPositions(Vector3 _firstpos, Vector3 _secondpos)
    {
        firstPos = _firstpos;
        secondPos = _secondpos;
    }
}

