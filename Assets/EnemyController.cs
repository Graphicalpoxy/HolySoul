using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Animator animator;
    //　歩くスピード
    public float Speed;

    //　移動方向
    private Vector3 direction;
    private Rigidbody rb;
    private GameObject player;
    public GameObject axe;
    private bool alive;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        axe.GetComponent<BoxCollider>().enabled = false;
        alive = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            direction = (player.transform.position - transform.position).normalized;
            transform.LookAt(player.transform.position);


            if (Vector3.Distance(transform.position, player.transform.position) > 2.5)
            {
                rb.velocity = direction * Speed;
                animator.SetFloat("Speed", 2.0f);
                animator.SetBool("Attack", false);
            }

            else if (Vector3.Distance(transform.position, player.transform.position) <= 2.5)
            {
                animator.SetBool("Attack", true);
            }
            if (GetComponent<EnemyStatus>().enemyHP <= 0)
            {
                animator.SetTrigger("Dead");
                alive = false;
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
        Debug.Log("攻撃終わり");
    }

    void DeadEnd()
    {
        Destroy(this.gameObject);
        player.GetComponent<PlayerStatus>().EXPup();
        Debug.Log("死亡");
    }


}
