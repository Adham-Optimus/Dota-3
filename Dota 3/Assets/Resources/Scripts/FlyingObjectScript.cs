using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObjectScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float speed;
    private Transform targetTransform;
    private float damage;
    private bool isRadiant;
    private bool isMagic;
    private bool canUpdate = false;

    public void FlyingObjectInstaller(float _damage, Transform _target, float _speed, Sprite _sprite, bool isMagic)
    {
        speed = _speed;
        targetTransform = _target;
        GetComponent<SpriteRenderer>().sprite = _sprite;
        damage = _damage;
        canUpdate = true;
    }

    private void FixedUpdate()
    {
        if (canUpdate && targetTransform)
        {
            Vector3 dir = targetTransform.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * 10, Space.World);
            if (dir.magnitude < 0.1f)
            {
                targetTransform.GetComponent<IDamagable>().TakeDamage(damage, isMagic);
                Destroy(gameObject);
            }
        }
        else if (targetTransform == null)
        {
            Destroy(gameObject);
        }
    }
}
