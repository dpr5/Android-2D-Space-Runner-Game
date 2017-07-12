using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BoundaryEnemy
{
    public float xMin, xMax, yMin, yMax;
}

public class EnemyAI : MonoBehaviour
{
    float fMinX = 50.0f;
    float fMaxX = 250.0f;

    public BoundaryEnemy boundary;
    Rigidbody2D rb;
    public float speed;
    public int destroyTime = 2;

    public GameObject bolt;
    private int health;
    public Transform shotSpawn1;
    public Transform shotSpawn2;

    public int enemyHealth = 100;
    private int damage;

    public Vector2 Target;
    public float timer;
    public int newtarget;

    public LayerMask enemyMask;
    public float speed1 = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;



    // Use this for initialization
    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

    }

    void FixedUpdate()
    {
        rb.position = new Vector3
         (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             //0.0F,
             Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax)
         );


        //NOTE: This script makes use of the .toVector2() extension method.
        //Be sure you have the following script in your project to avoid errors
        //http://www.devination.com/2015/07/unity-extension-method-tutorial.html

        //Use this position to cast the isGrounded/isBlocked lines from
        Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth + Vector2.up * myHeight;
        //Check to see if there's ground in front of us before moving forward
        //NOTE: Unity 4.6 and below use "- Vector2.up" instead of "+ Vector2.down"
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        //Check to see if there's a wall in front of us before moving forward
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f, enemyMask);

        //If theres no ground, turn around. Or if I hit a wall, turn around
        /*
        if (!isGrounded || isBlocked)
            {
                Vector3 currRot = myTrans.eulerAngles;
                currRot.y += 180;
                myTrans.eulerAngles = currRot;
            }
            */
        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }


    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= newtarget)
        {
            newTarget();
            timer = 0;
        }

        int value = Random.Range(0, 40);
        if (value == 1)
        {
            Instantiate(bolt, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(bolt, shotSpawn2.position, shotSpawn2.rotation);
        }
        if (value == 12)
        {
            //rb.velocity = transform.right * speed;
            //rb.transform.position += Vector3.right * speed * Time.deltaTime;
            //GetComponent <Rigidbody2D>().velocity = new Vector2(-movingSpeed,GetComponent<Rigidbody2D>().velocity.y);
        }
        if (value == 12)
        {
            //rb.velocity = transform.right * speed;
            rb.transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
    


 

    // Update is called once per frame
    


void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bolt")
        {
            enemyHealth = enemyHealth - damage;
            Destroy(other.gameObject);
        }
        if (enemyHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void newTarget()
    {
        float myX = gameObject.transform.position.x;

        float xPos = myX + Random.Range(myX + 100, myX - 100);

        Target = new Vector2(xPos, gameObject.transform.position.y);
    }
  
}

