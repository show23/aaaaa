using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
   
    [Header("��Player")]
    [CustomLabel("�����X�s�[�h")]
    public float moveSpeed = 30f;
    [CustomLabel("����X�s�[�h")]
    public float dashSpeed = 50f;

    [Header("�������񂹍U��")]
    [CustomLabel("�����񂹍U���{�^��")]
    public KeyCode attackKey = KeyCode.E; // �����񂹂�L�[
    [CustomLabel("�~���L����X�s�[�h")]
    public float increasedSpeed = 10.0f; // �L�[��������Ă���ԂɊg�傷��͈�
    [CustomLabel("�ő�̉~�̑傫��")]
    public float maxInteractionRange = 10.0f; // �ő勖�e����
    [CustomLabel("�����񂹂�͈�")]
    public float attractionRange = 10f;     // �����񂹂�͈�
    [CustomLabel("�����񂹂��")]
    public float attractionForce = 5f;      // �����񂹂��
    [CustomLabel("�����񂹂�ő呬�x")]
    public float maxSpeed = 10f;            // �ő呬�x
    [CustomLabel("��~����")]
    public float stopDistance = 2f;         // ��~����


    [Header("���������U��")]
    [CustomLabel("Enemy�̃^�O��")]
    public string enemyTag = "Enemy"; // �^�O�����w��
    [CustomLabel("�{�^���������鎞��")]
    public float buttonPressDuration = 5f; // �{�^����������ő厞�ԁi�b�j
    [CustomLabel("Player��Enemy�̔��苗��")]
    public float maxDistance = 5f;
    
    [Header("�G��Ȃ�")]
    public Camera mainCamera; // ���C���J�����̎Q��
   
    public Transform player; // �v���C���[��Transform���i�[���邽�߂̕ϐ�
    public LineRenderer lineRenderer;

    public GameObject beamPrefab; // �r�[���̃v���n�u
    public Transform firePoint;   // �r�[���̔��ˈʒu
    public float interactionRange = 0.0f; // Player��Enemy�̊Ԃ̋��e����



    private void OnDrawGizmos()
    {
        // �M�Y���̐F��ݒ�i��: �O���[���j
        Gizmos.color = Color.green;

        // �M�Y���͈̔͂�\��
        Gizmos.DrawWireSphere(transform.position, attractionRange);

        // �M�Y���̒�~������\��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
        // �M�Y���̐F��ݒ�
        Gizmos.color = Color.blue;

        // �M�Y���͈̔͂�\��
        Gizmos.DrawWireSphere(transform.position, maxDistance);
        // �M�Y���̐F��ݒ�
        Gizmos.color = Color.yellow;

        // �M�Y���͈̔͂�\��
        Gizmos.DrawWireSphere(transform.position, interactionRange);




    }
}
