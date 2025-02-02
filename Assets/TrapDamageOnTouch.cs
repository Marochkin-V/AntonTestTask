using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamageOnTouch : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerControl pc;
            other.gameObject.TryGetComponent<PlayerControl>(out pc);
            if (pc != null) pc.GetDamage(damage);
        }
    }
}
