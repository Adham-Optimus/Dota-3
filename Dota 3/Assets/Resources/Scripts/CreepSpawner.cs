using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepSpawner : MonoBehaviour
{
    [SerializeField]GameObject creep;
    [SerializeField]GameObject rangerCreep;
    [SerializeField] bool forestCreep;
    [SerializeField] bool canSpawn;
    public Vector3 firstPos;
    public Vector3 secondPos;

    private void FixedUpdate()
    {
        if (canSpawn)
        {
            StartCoroutine(Spawn());
        }
    }
    private IEnumerator Spawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(40);
        if (!forestCreep)
        {
            GameObject temp;
            for (int i = 0; i < 5; i++)
            {
                temp = Instantiate(creep,transform.position, Quaternion.identity);
                temp.GetComponent<CreepScript>().InstallPositions(firstPos, secondPos);
            }
            temp = Instantiate(rangerCreep, transform.position, Quaternion.identity);
            temp.GetComponent<CreepScript>().InstallPositions(firstPos, secondPos);
        }
        else
        {
            if (!Physics2D.OverlapCircle(transform.position, 60, 1 << 6))
            {
                Instantiate(creep, transform.position + Vector3.one, Quaternion.identity, transform);
                Instantiate(creep, transform.position + Vector3.zero, Quaternion.identity, transform);
                Instantiate(creep, transform.position + -Vector3.one, Quaternion.identity, transform);
            }
        }
        canSpawn = true;
    }
}
