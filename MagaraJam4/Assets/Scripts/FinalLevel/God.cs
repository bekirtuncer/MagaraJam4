using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Vector3 moveVec;
    [SerializeField] [Range(0, 1)] float moveFac;
    [SerializeField] float period = 2f;

    private float TimeBtwShots;
    public float StartTimeBtwShots;

    public GameObject Projectile;
    private Transform player;

    private void Start()
    {
        startPos = transform.position;

        player = GameObject.FindGameObjectWithTag("Ground").transform;

        TimeBtwShots = StartTimeBtwShots;
    }

    private void Update()
    {
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float ranSinWave = Mathf.Sin(cycles * tau);

        moveFac = (ranSinWave + 1f) / 2f;

        Vector3 offset = moveVec * moveFac;
        transform.position = startPos + offset;

        if(TimeBtwShots <= 0)
        {
            Instantiate(Projectile, transform.position, Quaternion.identity);
            TimeBtwShots = StartTimeBtwShots;
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
    }
}
