using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour, IDamagable
{
    [SerializeField] Camera camera;
    public NavMeshAgent agent;
    [SerializeField] GameObject levelPlusPannel;
    [SerializeField] Animator animator;
    [SerializeField] Text levelOfPlayer;
    [SerializeField] AtributesPanelScript atributes;
    public Transform target;

    GameObject body;
    public int againstSide;

    [Header("Levels of spells")]
    public int firstSpelllevel = 0;
    public int secondSpelllevel = 0;
    public int thirdSpelllevel = 0;
    public int fourthSpelllevel = 0;

    public float moneys = 600;
    public float percentOfMana;
    public float percentOfHP;
    public float mana;
    public float maxMana;
    public float hp;
    public float maxhp;
    public float speed;
    public float magicalResistance = 0.1f;
    public bool facingRight = false;

    public float xp;
    public float percentOfxp;
    public float maxxp;
    public int level;
    public float attackspeed;
    public int distanceToBeat;
    private Vector3 pos;
    public bool isBeating;

    [Header("Properties")]
    public float armor;
    public float damage;
    public float strength;
    public float agility;
    public float intelligence;
    public float hpRegen;
    public float manaRegen;
    [SerializeField] private char mainAttribute;

    [Header("Initial Values")]
    public int startArmor;
    public int startDamage;
    public int startStrength;
    public int startAgility;
    public int startIntelligence;

    [Header("Growth Values")]
    public float growthOfArmor;
    public float growthOfDamage;
    public float growthOfStrength;
    public float growthOfAgility;
    public float growthOfIntelligence;

    public Text text;
    public enum Heroes
    {
        VoidSpirit = 0,
        EmberSpirit = 1,
        StormSprit = 2
    }
    public Heroes hero = Heroes.VoidSpirit;

    private void Start()
    {
        body = transform.GetChild(1).gameObject;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        mana = maxMana;
        hp = maxhp;
        
        ArmorInstaller(startArmor);
        DamageInstaller(startDamage);
        StrengthInstaller(startStrength);
        AgilityInstaller(startAgility);
        IntelligenceInstaller(startIntelligence);
        agent.speed = speed;
        //camera = Camera.main;
        
    }

    
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            pos = camera.ScreenToWorldPoint(Input.mousePosition);
            if (pos.x < transform.position.x) { body.transform.localScale = new Vector3(-1, 1, 1); facingRight = false; }
            else if (pos.x > transform.position.x) { body.transform.localScale = Vector3.one; facingRight = true; }
            pos.z = 0;
            agent.isStopped = false;    
        }
        if (!agent.isStopped)
        {
            agent.SetDestination(pos);
            if (transform.position == pos) agent.isStopped = true; 
        }
    }

    private void FixedUpdate()
    {
        percentOfMana = mana / maxMana;
        percentOfHP = hp / maxhp;
        percentOfxp = xp / maxxp;
        if (!isBeating)
        {
            StartCoroutine(Beating());
        }
        HpInstaller(hpRegen * Time.deltaTime);
        ManaInstaller(manaRegen * Time.deltaTime);
    }
    public void ManaInstaller(float m)
    {
        mana += m;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        else if (mana < 0)
        {
            mana = 0;
        }

    }

    public void HpInstaller(float h)
    {
        hp += h;
        if (hp > maxhp)
        {
            hp = maxhp;
        }
        else if (hp < 0)
        {
            hp = 0;
        }
    }
    public void XPInstaller(float a)
    {
        xp += a;
        if (xp >= maxxp)
        {
            LevelUp(xp - maxxp);
        }
    }
    public void LevelUp(float a)
    {
        levelPlusPannel.SetActive(true);
        level++;
        levelOfPlayer.text = level.ToString();
        xp = 0;
        xp += a;
        ArmorInstaller(growthOfArmor);
        DamageInstaller(growthOfDamage);
        StrengthInstaller(growthOfStrength);
        AgilityInstaller(growthOfAgility);
        IntelligenceInstaller(growthOfIntelligence);
        maxxp += 100;
    }

    public void TakeDamage(float damage, bool isMagic)
    {
        if (isMagic)
        {
            HpInstaller(-(damage - (damage * magicalResistance)));
        }
        else
        {
            HpInstaller(-(damage - (damage * ((armor * 0.06f) / ((armor * 0.06f) + 1)))));
        }
    }
    private IEnumerator Beating()
    {
        isBeating = true;
        yield return new WaitForSeconds(1f/attackspeed * 100);
        Collider2D coll = Physics2D.OverlapCircle(transform.position, distanceToBeat, 1 << 6 | 1 << 8);
        if (coll != null)
        {
            animator.speed = attackspeed*0.01f;
            animator.Play("VoidSpiritBeating");
            coll.GetComponent<IDamagable>().TakeDamage(damage, false);  
        }
        isBeating=false;
    }

    public void ArmorInstaller(float a)
    {
        armor += a;
        atributes.armorText.text = "Armor: " + (int)armor;
    }

    public void DamageInstaller(float a)
    {
        damage += a;
        atributes.attackDamageText.text = "Attack Damage: " + (int)damage;
    }

    public void StrengthInstaller(float a)
    {
        strength += a;
        atributes.strengthText.text = "Strength: " + (int)strength;
        if (mainAttribute == 's') DamageInstaller(a);
        hpRegen += a * 0.1f;
        maxhp += a * 20;
        hp += a * 20;
    }

    public void AgilityInstaller(float a)
    {
        agility += a;
        atributes.agilityText.text = "Agility: " + (int)agility;
        if (mainAttribute == 'a') DamageInstaller(a);
        attackspeed += a;
        ArmorInstaller(a * 0.167f);
    }

    public void IntelligenceInstaller(float a)
    {
        intelligence += a;
        atributes.intelligenceText.text = "Intelligence: " + (int)intelligence;
        if (mainAttribute == 'i') DamageInstaller(a);
        manaRegen += a * 0.05f;
        maxMana += a * 12;
        mana += a * 12;
    }
}

/*for (int i = 0; i < 25; i++)
        {
            if (xp > (i * 100) & xp < ((i + 1) * 100))
            {
                levelPlusPannel.SetActive(true);
                levelOfPlayer.text = i.ToString();
                level = i;
                return;
            }
        }*/


/*case 0:startArmor = 3; startDamage = 56; startStrength = 23; startAgility = 19; startIntelligence = 27; growthOfArmor = 0.1f; growthOfDamage = 4.2f; growthOfStrength = 2.6f; growthOfAgility = 2.2f; growthOfIntelligence = 3.1f; break;
            case 1:startArmor = 4; startDamage = 60; startStrength = 24; startAgility = 20; startIntelligence = 24; growthOfArmor = 0.4f; growthOfDamage = 4.4f; growthOfStrength = 2.6f; growthOfAgility = 2.9f; growthOfIntelligence = 2.2f; break;
            case 2:startArmor = 2; startDamage = 55; startStrength = 22; startAgility = 18; startIntelligence = 29; growthOfArmor = 0.3f; growthOfDamage = 4.2f; growthOfStrength = 2; growthOfAgility = 1.7f; growthOfIntelligence = 3.9f; break;*/

