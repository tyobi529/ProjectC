using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class PlayerController : MonoBehaviourPunCallbacks
{
    public float left_x = -2f;
    public float center_x = 0f;
    public float right_x = 2f;

    public float up_y = 3f;

    Animator animator;
    BoxCollider2D collider;
    Rigidbody2D rigid;

    GameObject Camera;
    float different_y;

    bool isground = true;

    public int level = 1;

    GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();

        if (photonView.IsMine)
        {

            animator = GetComponent<Animator>();


            Camera = GameObject.Find("Main Camera");

            different_y = Camera.transform.position.y - transform.position.y;

            GameObject.Find("LeftButton").GetComponent<Button>().onClick.AddListener(OnLeftButton);
            GameObject.Find("CenterButton").GetComponent<Button>().onClick.AddListener(OnCenterButton);
            GameObject.Find("RightButton").GetComponent<Button>().onClick.AddListener(OnRightButton);


        }

        else
        {
            collider.enabled = false;
            rigid.gravityScale = 0;

            GetComponent<SpriteRenderer>().color = Color.blue;

        }


        //gameController = GameObject.Find("GameController(Clone)").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {


        if (photonView.IsMine)
        {
            //Camera.transform.position = new Vector3(0f, this.transform.position.y + different_y, -10f);

            if (isground)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    StartCoroutine("Jump");

                    transform.DOLocalMove(new Vector2(left_x, transform.position.y + up_y), 0.5f);

                    //Camera.transform.DOLocalMove(new Vector3(0, transform.position.y + different_y + up_y, -10f), 0.5f);

                }

                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    StartCoroutine("Jump");

                    transform.DOLocalMove(new Vector2(center_x, transform.position.y + up_y), 0.5f);

                    //Camera.transform.DOLocalMove(new Vector3(0, transform.position.y + different_y + up_y, -10f), 0.5f);

                }

                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    StartCoroutine("Jump");

                    transform.DOLocalMove(new Vector2(right_x, transform.position.y + up_y), 0.5f);

                    //Camera.transform.DOLocalMove(new Vector3(0, transform.position.y + different_y + up_y, -10f), 0.5f);

                }
            }

        }



    }


    public void OnLeftButton()
    {
        if (photonView.IsMine)
        {
            //animator.SetBool("isGround", false);
            StartCoroutine("Jump");

            transform.DOLocalMove(new Vector2(left_x, transform.position.y + up_y), 0.5f);
        }

    }

    public void OnCenterButton()
    {
        if (photonView.IsMine)
        {
            //animator.SetBool("isGround", false);
            StartCoroutine("Jump");

            transform.DOLocalMove(new Vector2(center_x, transform.position.y + up_y), 0.5f);
        }

    }

    public void OnRightButton()
    {
        if (photonView.IsMine)
        {
            //animator.SetBool("isGround", false);
            StartCoroutine("Jump");

            transform.DOLocalMove(new Vector2(right_x, transform.position.y + up_y), 0.5f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (photonView.IsMine)
        {
            if (collision.gameObject.tag == "Scaffold")
            {
                isground = true;

                animator.SetBool("isGround", isground);

                collision.gameObject.GetComponent<ScaffoldGenerator>().GenerateScaffold(level);

                Camera.transform.DOLocalMove(new Vector3(0f, collision.gameObject.transform.position.y + different_y + 2f, -10f), 0.2f);

            }
        }



    }






    IEnumerator Jump()
    {
        isground = false;

        animator.SetBool("isGround", isground);

        collider.isTrigger = true;

        yield return new WaitForSeconds(0.5f);

        //isground = true;

        //animator.SetBool("isGround", isground);

        collider.isTrigger = false;




    }

}
