using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    PlayerManager playerManager;
    // public float beamSpeed = 10f; // �r�[���̑��x
    //private float interactionRange = 0.0f; // Player��Enemy�̊Ԃ̋��e����
   

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        // �L�[��������Ă����
        if (Input.GetKey(playerManager.attackKey))
        {
            // interactionRange�𑝉�������
            playerManager.interactionRange += playerManager.increasedSpeed * Time.deltaTime;
            // interactionRange���ő勖�e�����𒴂��Ȃ��悤�ɐ���
            playerManager.interactionRange = Mathf.Min(playerManager.interactionRange, playerManager.maxInteractionRange);

        }
        else
        {
            InteractWithEnemy();
            // �L�[�������ꂽ��interactionRange�����ɖ߂�
            playerManager.interactionRange = 0.0f; // �����l�ɖ߂��A�K�v�ɉ����ĕύX

        }

        // �X�y�[�X�L�[�������ꂽ��r�[���𔭎�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��ԋ߂��̃J�������̓G��T��
            GameObject nearestEnemy = FindNearestEnemyInCamera();

            // �^�[�Q�b�g���ݒ肳��Ă���ꍇ
            if (nearestEnemy != null)
            {
                // �r�[���𔭎�
                ShootBeam(nearestEnemy);
            }
        }
    }

    void InteractWithEnemy()
    {
        // Player�̈ʒu
        Vector3 playerPosition = transform.position;

        // �͈͓��̑S�Ă�Enemy�����o
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            // Enemy��Player�̋������v�Z
            float distance = Vector3.Distance(playerPosition, enemy.transform.position);

            // ���e�������ɂ��邩�ǂ������m�F
            if (distance <= playerManager.interactionRange)
            {
                // Enemy��j��
                Destroy(enemy);
            }
        }
    }

    GameObject FindNearestEnemyInCamera()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // �G�̃^�O��ݒ肵�Ă���

        GameObject nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerManager.mainCamera); // �J�����̎�����ifrustum�j�̃v���[�����擾

        foreach (GameObject enemy in enemies)
        {
            if (GeometryUtility.TestPlanesAABB(planes, enemy.GetComponent<Collider>().bounds))
            {
                // �J�����̎�������ɂ���G������Ώۂɂ���
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < nearestDistance)
                {
                    nearestEnemy = enemy;
                    nearestDistance = distance;
                }
            }
        }

        return nearestEnemy;
    }

    void ShootBeam(GameObject target)
    {
        // �r�[�����v���t�@�u����C���X�^���X��
        GameObject beamInstance = Instantiate(playerManager.beamPrefab, playerManager.firePoint.position, playerManager.firePoint.rotation);

        // �r�[���̃X�N���v�g���擾
        Bullet beamScript = beamInstance.GetComponent<Bullet>();

        // �r�[���̃^�[�Q�b�g��ݒ�
        beamScript.SetTarget(target.transform);

        // ��莞�Ԍ�Ƀr�[����j�󂷂�i��F5�b��j
        Destroy(beamInstance, 5f);
    }

  
}