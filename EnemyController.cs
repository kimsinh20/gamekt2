using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool vertical;

    public float timestatic;
    float time;
    int huong = 1;

    public ParticleSystem smokeEffect;

    bool broken = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        time = timestatic;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            huong = -huong;
            time = timestatic;
        }

        if(!broken)
        {
            return;
        }
    }

    // FixedUpdate is changed frame on screen with time
    void FixedUpdate()
    {
        Vector2 position = rb.position;
        if (vertical)
        {
            position.y += speed * huong * Time.deltaTime;
        }
        else
        {
            position.x += speed * huong * Time.deltaTime;
        }
        rb.MovePosition(position);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if (player != null)
        {
            player.ChangeHP(-1);
        }
    }
    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        broken = false;
        GetComponent<Rigidbody2D>().simulated = false;

        smokeEffect.Stop();
    }
}
