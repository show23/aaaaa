using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttractor : MonoBehaviour
{
    PlayerManager playerManager;
    //public KeyCode attractionKey = KeyCode.Q; // �����񂹂�L�[
    private KeyCode attack;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    private void FixedUpdate()
    {
        attack = playerManager.attackKey;
        if (Input.GetKey(attack))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, playerManager.attractionRange);

            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    Rigidbody rb = col.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        // �v���C���[����G�ւ̕����x�N�g���Ƌ������v�Z
                        Vector3 directionToPlayer = transform.position - col.transform.position;
                        float distanceToPlayer = directionToPlayer.magnitude;

                        // �����񂹂�͂�K�p
                        if (distanceToPlayer > playerManager.stopDistance)
                        {
                            Vector3 attractionDirection = directionToPlayer.normalized;
                            rb.AddForce(attractionDirection * playerManager.attractionForce, ForceMode.Force);

                            // ���x�𐧌����čő呬�x�Ɏ���������
                            if (rb.velocity.magnitude > playerManager.maxSpeed)
                            {
                                rb.velocity = rb.velocity.normalized * playerManager.maxSpeed;
                            }
                        }
                        else
                        {
                            // ��~�������ɂ���ꍇ�A�͂��[���ɐݒ肵�Ē�~
                            rb.velocity = Vector3.zero;
                        }
                    }
                }
            }
        }
    }

    // �M�Y����\�����邽�߂̃��\�b�h
    
}
