using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player :  MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float flap;
    [SerializeField] GameObject preCloud;
    [SerializeField] GameObject preSnowball;
    int smokeStack;
    bool isJump;
    int shotInterval;
    bool BackOrFront;

    Rigidbody2D thisRigidbody2D;
    Health thisHealth;

    // Use this for initialization
    void Start() {
        thisRigidbody2D = GetComponent<Rigidbody2D>();
        thisHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 vel = thisRigidbody2D.velocity;
        thisRigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, vel.y);

        if (thisHealth.HP <= 0)
        {
            playerDead();
        }

        if (Input.GetKeyDown("z") && smokeStack >= 10)
        {
            Vector3 cloudPos;
            Vector3 pos = transform.position;
            if (Input.GetKey("down"))
            {
                cloudPos = new Vector3(pos.x, pos.y - 0.4f, pos.z);
            }
            else
            {
                float direc;
                if (BackOrFront)
                    direc = -0.6f;
                else
                    direc = 0.6f;
                cloudPos = new Vector3(pos.x + direc, pos.y + 0.35f, pos.z);
            }
            Instantiate(preCloud, cloudPos, transform.rotation);
            smokeStack -= 10;
        }

        if (Input.GetKey("x") && smokeStack != 0 && shotInterval == 0)
        {
            Vector3 pos = transform.position;
            float direc;
            if (BackOrFront)
                direc = -0.3f;
            else
                direc = 0.3f;

            GameObject snowball = Instantiate(preSnowball, new Vector3(pos.x + direc, pos.y, pos.z), transform.rotation);

            if (BackOrFront)
                snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(-8, 0);
            else
                snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(8, 0);

            shotInterval = 10;
            smokeStack--;
        }
        if (shotInterval != 0)
        {
            shotInterval--;
        }


        if (Input.GetKeyDown("left") && !BackOrFront)
        {
            transform.localScale = new Vector3(-0.2f, 0.4f, 0.2f);
            BackOrFront = true;
        }
        if (Input.GetKeyDown("right") && BackOrFront)
        {
            transform.localScale = new Vector3(0.2f, 0.4f, 0.2f);
            BackOrFront = false;
        }

        if (Input.GetKeyDown("space") && !isJump)
        {
            vel = thisRigidbody2D.velocity;
            thisRigidbody2D.velocity = new Vector2(vel.x, flap);
            isJump = true;
        }

        Debug.Log(smokeStack);
    }

    void playerDead()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
        return;
    }

    public void CanNotJump()
    {
        isJump = false;
    }

    public int smokeValue()
    {
        return smokeStack;
    }

    public void smokeAdd(){
        smokeStack++;
        if (smokeStack > 100)
            smokeStack = 100;
    }
}
