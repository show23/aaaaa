using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float detectionRange = 10f; // �v���C���[�����o����͈�
    public float chaseRange = 20f; // �v���C���[��ǂ�������͈�
    public float retreatRange = 30f; // �P�̍s���ɖ߂�͈�
    public float speed = 10f;
    
    public Transform player; // �v���C���[�I�u�W�F�N�g�̎Q��
    public float stoppingDistance = 0.1f; // ��~����
    public float detectionAngle = 45.0f; // ���m����p�x

    private Vector3 initialPosition; // �ŏ��̈ʒu��ێ����邽�߂̕ϐ�
    public float rotationSpeed = 5.0f; // ��]���x�i�p�x��ς��鑬�x�j
    private float returnSpeed = 20f; // �ŏ��̈ʒu�ɖ߂鑬�x�i�����\�j

    private bool playerLook;
    private void Start()
    {
        // �ŏ��̈ʒu���L�^����
        initialPosition = transform.position;
    }
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (player != null)
        {
            // �v���C���[�ւ̃x�N�g�����v�Z
            Vector3 playerDirection = player.position - transform.position;
            playerDirection.y = 0; // �����̍��𖳎�

            // ���g�̑O���x�N�g���ƃv���C���[�ւ̃x�N�g���̊p�x���v�Z
            float angle = Vector3.Angle(transform.forward, playerDirection);

            // ���m�p�x���Ƀv���C���[�����邩���m�F
            if (angle <= detectionAngle && distanceToPlayer < retreatRange)
            {
                // �v���C���[�����o�����ꍇ
                ChasePlayer();
                NotifyOtherEnemies();
            }
            else if (distanceToPlayer > retreatRange)
            {
                // �P�̍s���ɖ߂�ꍇ
                ReturnToBase();
            }
        }
        
        
    }


    void ChasePlayer()
    {
        playerLook = true;
        
        // �v���C���[�����E���ɓ���ΑS���ǂ�������
        Vector3 playerDirection = player.position - transform.position;
        playerDirection.y = 0; // �����̍��𖳎�

        // �v���C���[�̕���������
        Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // �G�̈ړ��𐧌䂷��ꍇ�́ANavMesh���g�p������A�ȉ��̂悤��Transform�𑀍�ł��܂��B
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // �����ŃA�j���[�V�����𐧌䂷��R�[�h��ǉ�����
       
        // �v���C���[�Ƃ̋��������ȉ��ɂȂ�����U���Ȃǂ̍s����ǉ�����
        if (Vector3.Distance(transform.position, player.position) < 2f)
        {
            // �U���Ȃǂ̍s����ǉ�����
        }
    }

    void ReturnToBase()
    {
        // �ڕW�ʒu�ւ̕����x�N�g�����v�Z
        Vector3 direction = initialPosition - transform.position;

        // �ڕW�ʒu�ɏ\���ɋ߂Â�����ړ����~
        if (direction.magnitude <= stoppingDistance)
        {
            // �����ڕW�ʒu�ɓ��B������A�ʒu�𐳊m�ɐݒ肵�Ĕ�����h��
            transform.position = initialPosition;
        }
        else
        {
            // �����x�N�g���𐳋K�����đ��x��������
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;

            // ���݈ʒu����ڕW�ʒu�Ɍ������ď������ړ�������
            transform.position += velocity;
        }
    }

    void NotifyOtherEnemies()
    {
        // ���̃G�l�~�[�Ƀv���C���[�����o���ꂽ���Ƃ�ʒm
        foreach (Enemy otherEnemy in FindObjectsOfType<Enemy>())
        {
            if (otherEnemy != this)
            {
                otherEnemy.playerLook = true;
                otherEnemy.ChasePlayer();
            }
        }
    }
    private void OnDrawGizmos()
    {

       
        // �M�Y���̐F��ݒ�
        Gizmos.color = Color.black;

        // �M�Y���͈̔͂�\��
        Gizmos.DrawWireSphere(transform.position, retreatRange);
    }
}


