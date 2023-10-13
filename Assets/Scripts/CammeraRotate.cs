using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraRotate : MonoBehaviour
{
    //�@�L�����N�^�[��Transform
    [SerializeField]
    private Transform charaLookAtPosition;
    //�@�J�����̈ړ��X�s�[�h
    [SerializeField]
    public float cameraMoveSpeed = 2f;
    //�@�J�����̉�]�X�s�[�h
    [SerializeField]
    public float cameraRotateSpeed = 90f;
    //�@�J�����̃L�����N�^�[����̑��Βl���w��
    [SerializeField]
    private Vector3 basePos = new Vector3(0f, 0f, 2f);
    // ��Q���Ƃ��郌�C���[
    [SerializeField]
    private LayerMask obstacleLayer;

    void FixedUpdate()
    {
        //�@�ʏ�̃J�����ʒu���v�Z
        var cameraPos = charaLookAtPosition.position + (-charaLookAtPosition.forward * basePos.z) + (Vector3.up * basePos.y);
        //�@�J�����̈ʒu���L�����N�^�[�̌�둤�Ɉړ�������
        transform.position = Vector3.Lerp(transform.position, cameraPos, cameraMoveSpeed * Time.deltaTime);

        RaycastHit hit;
        //�@�L�����N�^�[�ƃJ�����̊Ԃɏ�Q�������������Q���̈ʒu�ɃJ�������ړ�������
        if (Physics.Linecast(charaLookAtPosition.position, transform.position, out hit, obstacleLayer))
        {
            transform.position = hit.point;
        }
        //�@���C�����o�I�Ɋm�F
        Debug.DrawLine(charaLookAtPosition.position, transform.position, Color.red, 0f, false);

        //�@�X�s�[�h���l�����Ȃ��ꍇ��LookAt�ŏo����
        //transform.LookAt(charaTra.position);
        //�@�X�s�[�h���l������ꍇ
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(charaLookAtPosition.position - transform.position), cameraRotateSpeed * Time.deltaTime);
    }
}
