using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour, IDamagable
{
    [SerializeField]Sprite projectile;
    [SerializeField] float speedOfProjectile;
    private BarOnTower bar;

    public float damage;
    public float armor;
    private float maxHp;
    [SerializeField]private float hp;
    public float distance;
    public bool isRadiant;
    private int againstSide;
    public bool invulnerability;
    [SerializeField] TowerScript ancient;

    [SerializeField] bool canShoot = true;
    public enum Towers
    {
        T1 = 0,
        T2 = 1,
        T3 = 2,
        T4 = 3,
        Ancient = 4
    }
    public Towers tower = Towers.T1;
    private void Start()
    {
        bar = GetComponentInChildren<BarOnTower>();
        switch ((int)tower)
        {
            case 0: damage = 100;armor = 6;maxHp = 1000; break;
            case 1: damage = 120;armor = 8;maxHp = 1500; break;
            case 2: damage = 150;armor = 9;maxHp = 1800; break;
            case 3: damage = 150;armor = 10;maxHp = 2200; break;
            case 4: damage = 0;armor = 30;maxHp = 6000; break;
        }
        hp = maxHp;
        if (isRadiant) againstSide = 256;
        else if (!isRadiant) againstSide = 128;
    }

    private void FixedUpdate()
    {
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);
        Collider2D coll = Physics2D.OverlapCircle(transform.position, distance, againstSide);
        if (coll != null)
        {
            GameObject flyingObject = Instantiate(Resources.Load<GameObject>("Prefabs/Other/FlyingObject"), transform);
            flyingObject.GetComponent<FlyingObjectScript>().FlyingObjectInstaller(damage, coll.transform, speedOfProjectile, projectile, false);
        }
        canShoot = true;
    }

    public void TakeDamage(float _damage, bool isMagic = false)
    {
        if (!invulnerability)
        {
            hp -= (_damage - (_damage * ((armor * 0.06f) / ((armor * 0.06f) + 1))));
            bar.BarHP(hp / maxHp);
        }
        
        if(hp <= 0)
        {
            if ((int)tower == 3) { ancient.invulnerability = false; Destroy(gameObject); }
            else if ((int)tower == 4) { GameManager.GameEnd(!isRadiant); }
            else Destroy(gameObject);
        }

    }
}