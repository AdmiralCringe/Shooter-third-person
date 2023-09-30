using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TwinsMonster : EnemyBehaviour
{
    public TwinsMonster(float healthPoint, float damage, float zombieMovement, float rangeChase, float rangeAttack, float rangeStopping, Animator animator, NavMeshAgent agent) : base(healthPoint, damage, zombieMovement, rangeChase, rangeAttack, rangeStopping, animator, agent)
    {
    }

    private GameObject shard;
    private GameObject twinsPointAttack;
    
    public override void Attack()
    {
        player.GetComponent<HealthPlayer>().GetDamage(damage);
        player.GetComponent<HealthPlayer>().GetDamage(damage);

        GameObject.Instantiate(shard, twinsPointAttack.transform.position, twinsPointAttack.transform.rotation);
    }

    public override void GetDamage(float damage)
    {
        currentHealthPointEnemy -= damage;
    }

    public override void Start()
    {
        currentHealthPointEnemy = healthPoint;
        shard = GameObject.Find("Shard");
        twinsPointAttack = GameObject.Find("TwinsPointAttack");
    }

    
}
