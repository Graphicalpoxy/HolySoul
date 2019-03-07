using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController2 : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;
    private Animator animator;

    public float moveSpeed ;

    public GameObject guard;
    public GameObject axe;

    private PlayerStatus playerstatus;
    private bool alive;

    public bool guardtrigger;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        axe.GetComponent<BoxCollider>().enabled = false;
        playerstatus = GetComponent<PlayerStatus>();
        alive = true;
        guardtrigger = false;
    }

    void Update()
    {


        inputHorizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        inputVertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);


        guard.SetActive(false);

        if (alive == true)
        {
            // キャラクターの向きを進行方向に
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }

            if (inputHorizontal != 0 || inputVertical != 0)
            {
                animator.SetBool("Run", true);
            }
            else if (inputHorizontal == 0 && inputVertical == 0)
            {
                animator.SetBool("Run", false);
            }

           // if (Input.GetMouseButtonDown(0))
            //{
            //    Attack();
            //}

            if (guardtrigger == true)
            {
                guard.SetActive(true);
            }

            if (playerstatus.HP <= 0)
            {
                Dead();
                alive = false;
            }
        }

    }

    public void Attack()
    {
        animator.SetBool("Attack", true);
       
    }

    void AttackStart()
    {
        axe.GetComponent<BoxCollider>().enabled = true;
    }

    void AttackEnd()
    {
        animator.SetBool("Attack", false);
        axe.GetComponent<BoxCollider>().enabled = false;
    }

    void Dead()
    {
        animator.SetTrigger("Dead");        
    }

    void DeadEnd()
    {
        SceneManager.LoadScene("Home");
    }

    public void GuardButtomDown()
    {
        guardtrigger = true;
    }
    public void GuardButtomUp()
    {
        guardtrigger = false;
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SceneChanger")
        {
            SceneManager.LoadScene("Battlefield");
        }
        if (other.gameObject.tag == "Homemover")
        {
            SceneManager.LoadScene("Home");
        }

    }


}
