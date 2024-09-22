// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// public class BossRun : StateMachineBehaviour
// {
//     public float speed = 5.0f;
//     public float attackRange = 3.5f;

//     Transform player;
//     Rigidbody2D rb;
//     Boss boss;

//     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//         rb = animator.GetComponet<Rigidbody2D>();
//         boss = animator.GetComponet<boss>();
//     }

//     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//         boss.LookAtPlayer();

//         Vector2 target = new Vector2(player.position.x, rb.position.y);
//         Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
//         if (playerHealth.health > 0)
//         {
//             rb.MovePosition(newPos);
//         }

//         if (Vector2.Distance(player.position, rb.position) <= attackRange)
//         {
//             BossAttack bossAttack = boss.GetComponent<BossAttack>();
//             bossAttack.Attack();
//         }
//     }

//     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//         animator.ResetTrigger("IsAttacking");
//     }
// }