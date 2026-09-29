using System.Collections;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float speed;

    
    private Vector2 direction;
    private Rigidbody2D rigidbody2D;


    private bool rolling;
    private bool hammering;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();  
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        HammerAttack();

        if (hammering == false)
        {
            Move();
            Roll();
        }
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    void Move()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0.0f, 0.0f);
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0.0f, 180.0f);
        }
    }

    void OnMove()
    {
        rigidbody2D.linearVelocity  = direction.normalized * speed;
    }


    void Roll()
    {
        if(Input.GetButtonDown("Jump") && direction.x != 0.0f)
        {
            rolling = true;
        }
        else
        {
            rolling = false;
        }
    }

    void HammerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(HammerState());
        }
    }

    IEnumerator HammerState()
    {
        hammering = true;
        yield return new WaitForSeconds(0.25f);
        hammering = false;
    }



    public int DirectionSpeed()
    {
        return (int)(Mathf.Abs(direction.x) + Mathf.Abs(direction.y));
    }


    public bool Rolling() 
    {
        return rolling;
    }


    public bool Hammering()
    {
        return hammering;
    }

}
