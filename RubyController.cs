using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 3.0f;
    float horizontal;
    float vertical;

    public int maxHP = 5;
    int currentHP;

    public GameObject dan;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }
    }

    // FixedUpdate is changed frame on screen with time
    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;
        rb.MovePosition(position);
    }

    //Change HP of ruby while instance
    public void ChangeHP(int hp)
    {
        currentHP = Mathf.Clamp(currentHP + hp, 0, maxHP);
        UIHealthBar.instance.SetValue(currentHP / (float)maxHP);
    }

    //Dùng đế bắn đạn 
    void Launch()
    {
        GameObject danObject = Instantiate(dan, rb.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile p = danObject.GetComponent<Projectile>();
        p.Launch(lookDirection, 300);
    }
}
