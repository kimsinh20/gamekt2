using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 10.0f)
        {
            Destroy(gameObject);
        }
    }
    //Hàm điểu khiển đạn bắn
    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }
    //Hàm phá hủy đạn khi chạm vào con Bot
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.fix();
        }

        Destroy(gameObject);
    }
}
