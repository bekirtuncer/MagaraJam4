using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    public float _speed;
    public float _stoppingDistance;
    public float _retreatDistance;

    private Transform player;


    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 finalPos = transform.position;
        RaycastHit rH;
        Physics.Raycast(transform.position, -transform.up, out rH, 2f);

        if (Vector3.Distance(transform.position, player.position) > _stoppingDistance)
        {
            finalPos = Vector3.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
        }else if (Vector3.Distance(transform.position, player.position) < _stoppingDistance && Vector3.Distance(transform.position, player.position) > _retreatDistance)
        {
            finalPos = transform.position = this.transform.position;
        }else if(Vector3.Distance(transform.position, player.position) < _retreatDistance)
        {
            finalPos = transform.position = Vector3.MoveTowards(transform.position, player.position, -_speed * Time.deltaTime);
        }

        if(rH.collider && rH.collider.tag != "Player" && (finalPos.y - transform.position.y) <= 0)
        {
            finalPos.y = rH.point.y + 1.5f;
        }

        transform.position = finalPos;

        Vector3 diff = (player.position - transform.position).normalized;
        float lookRot = Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg + 90.0f;
        Vector3 rotEuler = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rotEuler.x, lookRot, rotEuler.z);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Stamina.instance.DPRHÝT(50);
        }     
    }

    
}
