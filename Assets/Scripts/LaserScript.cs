using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject laserVFX; // ���[�U�[VFX��Prefab
    public Transform emitterTransform; // ���[�U�[�̔��ˈʒu
    public float laserRange = 100f; // ���[�U�[�̎˒�����

    private LineRenderer laserLine; // ���[�U�[���C��
    private RaycastHit hitInfo; // ���C�L���X�g�����������I�u�W�F�N�g�̏��

    void Start()
    {
        // ���[�U�[���C���̏�����
        laserLine = GetComponent<LineRenderer>();
        laserLine.enabled = false; // ������Ԃł͔�\��
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireLaser();
        }

        // ���[�U�[���\���ɂ���
        laserLine.enabled = false;
    }

    void FireLaser()
    {
        // ���[�U�[��\��
        laserLine.enabled = true;

        // ���[�U�[VFX�𐶐�
        GameObject currentLaser = Instantiate(laserVFX, emitterTransform.position, emitterTransform.rotation);

        // ���[�U�[�̕������v�Z
        Vector3 direction = emitterTransform.forward;

        // ���C�L���X�g�����s���ēG�ɓ����邩�ǂ����𔻒�
        if (Physics.Raycast(emitterTransform.position, direction, out hitInfo, laserRange))
        {
            // ���[�U�[���C���̈ʒu��ݒ�
            laserLine.SetPosition(0, emitterTransform.position);
            laserLine.SetPosition(1, hitInfo.point);

            // �q�b�g�����I�u�W�F�N�g�ɑ΂��鏈���������Ŏ��s
            GameObject hitObject = hitInfo.collider.gameObject;
            if (hitObject.CompareTag("Enemy"))
            {
                // �����œG�Ƀ_���[�W��^���邩�A�j�󂷂�Ȃǂ̃A�N�V���������s
                // ��: hitObject.GetComponent<EnemyScript>().TakeDamage(damageAmount);
            }
        }
        else
        {
            // ���[�U�[���C���̈ʒu��ݒ�i�˒������܂ŐL�΂��j
            laserLine.SetPosition(0, emitterTransform.position);
            laserLine.SetPosition(1, emitterTransform.position + direction * laserRange);
        }

        // ���[�U�[VFX�������x�����Ĕj��
        Destroy(currentLaser, 0.1f);
    }
}
