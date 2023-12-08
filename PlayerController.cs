using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg;
    Animator anim;
    float speed = 5.0f;
    float divX;
    float divY;
    int currenthealth;
    int health { get { return currenthealth; } }
    int maxhealth = 5;
    public float timetrumau = 2.0f;

    bool istrumau;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        divX = Input.GetAxisRaw("Horizontal");
        divY = Input.GetAxisRaw("Vertical");
        if(divX>0)
        {
            anim.SetInteger("state", 1);
        } else if(divX<0)
        {
            anim.SetInteger("state", 2);
        } else
        {
            anim.SetInteger("state", 0);
        }
        if(istrumau)
        {
            time -= Time.deltaTime;
            if(time<0)
            {
                istrumau = false;
            }
        }
    }
    void FixedUpdate()
    {
        //Vector2 position = rg.position;
        //position.x += divX * speed * Time.deltaTime;
        //position.y += divY * speed * Time.deltaTime;
        //rg.MovePosition(position);
        rg.velocity = new Vector2(divX * speed, divY * speed);
    }
    public void changeHealth(int amount)
    {
        if(amount<0)
        {
            if(istrumau)
            {
                return;
            }
            istrumau = true;
            time = timetrumau;
        }
        currenthealth = Mathf.Clamp(currenthealth + amount, 0, maxhealth);
        Debug.Log(currenthealth+"/"+maxhealth);
    }
}
