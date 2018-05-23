using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanon : MonoBehaviour
{

    [SerializeField] GameObject preBullet;
    [SerializeField] int shotInterval;
    [SerializeField] float range;
    [SerializeField] float shotSpeed;

    Player _pl;

    // Use this for initialization
    void Start()
    {
        _pl = GameManager.Instance.pl;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 thisPos = this.transform.position;
        Vector3 plPos = _pl.transform.position;
        float dis = Vector3.Distance(thisPos, plPos);

        if (dis < range)
        {
            if (shotInterval <= 0)
            {
                GameObject bullet = Instantiate(preBullet, thisPos, transform.rotation);
                Vector3 homing;
                homing = plPos - thisPos;
                homing.Normalize();
                Rigidbody2D bulRig = bullet.GetComponent<Rigidbody2D>();
                bulRig.velocity = homing * shotSpeed;

                shotInterval = 1000;
            }
        }

        if (shotInterval > 0) { shotInterval--; }
    }
}
