using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEBlast : Ability
{
    public override void Use(Vector3 spawnPos)
    {
        RaycastHit[] hits = Physics.CapsuleCastAll(spawnPos, spawnPos, m_info.range,  transform.forward, m_info.range);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyController>().DecreaseHealth(m_info.power);
            }
        }

        var emitterShape = cc_ps.shape;
        emitterShape.length = m_info.range;
        cc_ps.Play();
    }
}
