// using System.Collection;
// using System.Collection.Generic;
// using UnityEngine;

// public class BossAttack : MonoBeahaviour
// {
//     public int attackDamage = 10;
//     public int enragedAttackDamage = 20;

//     public Vector3 attackOffset;
//     public float attackRanger = 3.7f;
//     public LayerMask attackMask;
//     public Animator animator;
//     private bool canAttack = true;
//     Boss boss;

//     public void Attack()
//     {
//         if (canAttack)
//         {
//             canAttack = false;
//             animator.SetTrigger("IsAttacking");
//             Vector3 pos = transform.position;

//             Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
//             Debug.Log(colInfo);
//             if (colInfo != null)
//             {
//                 colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
//             }
//             StartCoroutine(DelayAttack());
//         }
//     }

//     IEnumerator DelayAttack()
//     {

//         yield return new WaitForSeconds(2.0f);
//         canAttack = true;
//     }
// }