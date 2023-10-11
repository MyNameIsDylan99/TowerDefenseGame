using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTowerBullet : MonoBehaviour
{
    [SerializeField]
    int damage = 1;
    [SerializeField]
    int pierce  = 1;
    public float speed = 150f;
    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pierce > 0)
        {
            if (collision.collider.tag == "Enemy")
            {
                if (!collision.gameObject.name.StartsWith("1")&& !collision.gameObject.name.StartsWith("2") && !collision.gameObject.name.StartsWith("3"))
                {
                    pierce = pierce-1;
                    collision.gameObject.name = pierce + collision.gameObject.name;
                    collision.collider.GetComponent<Enemy>().TakeDamage(damage);
                    if (pierce <= 0)
                        Destroy(gameObject);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(1f*speed*Time.fixedDeltaTime,0f,0f));
    }

}
