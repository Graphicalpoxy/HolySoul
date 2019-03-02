using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyState
    {
        Wait,
        Chase,
        Guard,
        Attack,
        AttackWait,
        Freeze
    };

    private float freezeTime = 0.3f;


    private Animator animator;
    //　歩くスピード
    public float Speed;

    //　移動方向
    private Vector3 direction;
    private Rigidbody rb;
    private GameObject player;
    public GameObject axe;
    private bool alive;

    private float waittime;
    public bool waitend;

    private float acttime;
    private bool attacktrigger;

    public GameObject guard;

    private bool actset;

    //　敵の状態
    private EnemyState state;

    //　敵キャラクターの状態変更メソッド
    public void SetState(string mode, Transform obj = null)
    {
        if (mode == "wait")
        {           
            state = EnemyState.Wait;         
        }
        else if (mode == "chase")
        {
            state = EnemyState.Chase;
            Speed = 2;
            animator.SetFloat("Speed", 2.0f);
            animator.SetBool("Attack", false);
        }
        else if (mode == "guard")
        {
            state = EnemyState.Guard;
            animator.SetFloat("Speed", 2.0f);
        }
        else if (mode == "attack")
        {
            state = EnemyState.Attack;
        }
        else if (mode == "attackwait")
        {
            state = EnemyState.AttackWait;           
            animator.SetFloat("Speed", 2.0f);
            Speed = 1;
        }
        else if (mode == "freeze")
        {
            state = EnemyState.Freeze;
        }
    }

    public EnemyState GetState()
    {
        return state;
    }



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        axe.GetComponent<BoxCollider>().enabled = false;
        SetState("chase");
        alive = true;
        waittime = 0;
        waitend = false;
        acttime = 0;
        attacktrigger = true;
        actset = true;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);
        Debug.Log(waitend);       

        if (alive == true)
        {
            direction = (player.transform.position - transform.position).normalized;
            transform.LookAt(player.transform.position);

            if (Vector3.Distance(transform.position, player.transform.position) >2.5f)
            {
                SetState("chase");
                waitend = false;
                waittime = 0;
                acttime = 0;
                actset = true;
                if (state == EnemyState.Chase)
                {
                rb.velocity = direction * Speed;
                }
            }

            if (Vector3.Distance(transform.position, player.transform.position) <= 2.5f)
            {
               
                if (waitend == false)
                {
                    attacktrigger = true;
                    guard.SetActive(false);

                    waittime += Time.deltaTime;
                    if (waittime > 1.5f)
                    {
                        waitend = true;
                    }
                }
                if (waitend == true)
                {
                    if (actset == true)
                    {
                        int i = Random.Range(0, 3);
                        Debug.Log(i);
                        if (i == 0)
                        {
                            SetState("attack");
                            actset = false;
                        }
                        if (i == 1)
                        {
                            SetState("guard");
                            actset = false;
                        }
                        if (i == 2)
                        {
                            SetState("attackwait");
                            actset = false;
                        }

                    }
                }
            }
            //攻撃
                    if (state == EnemyState.Attack)
                    {                    
                        acttime += Time.deltaTime;
                        if (attacktrigger == true)
                        {
                            animator.SetTrigger("Attack");
                            attacktrigger = false;
                        }
                        if (acttime > 2)
                        {
                            waitend = false;
                            waittime = 0;
                            acttime = 0;
                            actset = true;
                        }

                    }
                    //ガード
                    if (state == EnemyState.Guard)
                    {                       
                        transform.RotateAround(player.transform.position, Vector3.up, 0.3f);
                        guard.SetActive(true);
                        acttime += Time.deltaTime;
                        if (acttime > 2)
                        {
                            animator.SetBool("Attack", false);
                            waitend = false;
                            waittime = 0;
                            acttime = 0;
                            actset = true;
                        }
                    }
                    //待機
                    if (state == EnemyState.AttackWait)
                    {
                        transform.RotateAround(player.transform.position, Vector3.up, 0.3f);
                        acttime += Time.deltaTime;
                        if (acttime > 2)
                        {
                            waitend = false;
                            waittime = 0;
                            acttime = 0;
                            actset = true;
                        }
                    }
                
            




            if (GetComponent<EnemyStatus>().enemyHP <= 0)
            {
                    alive = false;
                animator.SetTrigger("Dead");
            }

        }
        




    }

    void AttackStart()
    {
        axe.GetComponent<BoxCollider>().enabled = true;
    }

    void AttackEnd()
    {
        axe.GetComponent<BoxCollider>().enabled = false;
        animator.SetBool("Attack", false);
        animator.SetFloat("Speed", 0f);
        waittime = 0;
    }

    void DeadEnd()
    {
        Destroy(this.gameObject);
        player.GetComponent<PlayerStatus>().EXPup();
    }


}
