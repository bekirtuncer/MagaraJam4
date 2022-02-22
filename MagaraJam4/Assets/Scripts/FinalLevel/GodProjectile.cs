using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodProjectile : MonoBehaviour
{
    public float Speed;

    private Transform Player;
    private Vector3 Target;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("other").transform;

        Target = new Vector3(Player.position.x, Player.position.y, Player.position.z);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
        if(transform.position.x == Target.x && transform.position.y == Target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BossBar.instance.PickBossPower(10);
            Destroy(gameObject);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject, 5);
    }
}
