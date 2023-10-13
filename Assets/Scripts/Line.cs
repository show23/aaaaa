using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    PlayerManager playerManager;
    //�V���O���g��
   
   
    private List<Transform> touchedEnemies = new List<Transform>(); // �v���C���[���G�ꂽ�G���L�^���郊�X�g
    private float speed;
    private float originalSpeed; // �I���W�i���̑��x��ۑ�����ϐ�
    private bool isDrawingLine = false;
    private float buttonPressTime = 0f; // �{�^���������ꂽ����
   
    private Transform lastTouchedEnemy; // �Ō�ɐG�ꂽ�G��Transform���L�^����ϐ�

  
    
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        originalSpeed = playerManager.moveSpeed; // �Q�[���J�n���̑��x��ۑ�
    }

    void Update()
    {
        speed = playerManager.dashSpeed;
       

        // ���N���b�N�������ꂽ�����`�F�b�N
        if (Input.GetMouseButtonDown(0))
        {
            if (!isDrawingLine)
            {
                //����
                buttonPressTime = Time.time;
            }
            isDrawingLine = true;
            originalSpeed = speed;
        }

        // ���N���b�N�������ꂽ�ꍇ�A�����\���ɂ��A���X�g���N���A
        if (Input.GetMouseButtonUp(0) || (isDrawingLine && Time.time - buttonPressTime >= playerManager.buttonPressDuration))
        {
            isDrawingLine = false; // ����`�撆�łȂ���Ԃɂ���
            playerManager.lineRenderer.positionCount = 0; // �����\���ɂ���
            speed = originalSpeed; // �I���W�i���̑��x�ɖ߂�
            touchedEnemies.Clear(); // ���X�g����ɂ���
        }

        if (isDrawingLine)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(playerManager.enemyTag); // �^�O��"Enemy"�̓G�I�u�W�F�N�g���擾

            foreach (GameObject enemy in enemies)
            {
                // �v���C���[�ƓG�̋������v�Z
                float distance = Vector3.Distance(playerManager.player.position, enemy.transform.position);

                if (distance < playerManager.maxDistance)
                {
                    touchedEnemies.Add(enemy.transform);
                    lastTouchedEnemy = enemy.transform;
                }
                //Debug.Log($"Player��{enemy.name}�̋���: {distance}");
            }

            // ����`�撆���{�^����������Ă���ꍇ�A����`��
            // �{�^����������Ă���Ƃ������G�Ƃ̋������`�F�b�N
            if (touchedEnemies.Count > 0)
            {
                // ���̒�����ݒ�
                playerManager.lineRenderer.positionCount = touchedEnemies.Count + 2; // +2 ��Player�ƍŌ�ɐG�ꂽ�G�ւ̐�����ǉ�

                // Player����Ō�ɐG�ꂽ�G�ւ̐���`��
                playerManager.lineRenderer.SetPosition(0, transform.position);

                // �Ō�ɐG�ꂽ�G�ւ̐���`��
                if (lastTouchedEnemy != null)
                {
                    Vector3 lastEnemyPosition = lastTouchedEnemy.position;
                    playerManager.lineRenderer.SetPosition(1, lastEnemyPosition);
                }

                // ���X�g����j�����ꂽ�I�u�W�F�N�g���폜���Ȃ������`��
                int currentIndex = 2; // �C���f�b�N�X2����G�Ƃ̐���`��
                for (int i = 0; i < touchedEnemies.Count;)
                {
                    Transform enemyTransform = touchedEnemies[i];

                    // Transform�I�u�W�F�N�g���j������Ă��邩�ǂ������`�F�b�N
                    if (enemyTransform != null)
                    {
                        Vector3 enemyPosition = enemyTransform.position;
                        playerManager.lineRenderer.SetPosition(currentIndex, enemyPosition);
                        currentIndex++;
                        i++; // ���̓G���`�F�b�N
                    }
                    else
                    {
                        // �j�����ꂽ�I�u�W�F�N�g�����X�g����폜
                        touchedEnemies.RemoveAt(i);
                    }
                }

                // �j�����ꂽ�I�u�W�F�N�g�����X�g����폜������A�]���Ȓ��_���N���A
                for (int i = currentIndex; i < playerManager.lineRenderer.positionCount; i++)
                {
                    playerManager.lineRenderer.SetPosition(i, Vector3.zero);
                }
            }
        }
    }
    //void Update()
    //{
    //    PlayerMove playermove = GetComponent<PlayerMove>();
    //    speed = playermove.moveSpeed;

    //    // ���N���b�N�������ꂽ�����`�F�b�N
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (!isDrawingLine)
    //        {
    //            //����
    //            buttonPressTime = Time.time;
    //        }
    //        isDrawingLine = true;
    //        playermove.moveSpeed = 50;
    //    }

    //    // ���N���b�N�������ꂽ�ꍇ�A�����\���ɂ��A���X�g���N���A
    //    if (Input.GetMouseButtonUp(0) || (isDrawingLine && Time.time - buttonPressTime >= buttonPressDuration))
    //    {
    //        isDrawingLine = false; // ����`�撆�łȂ���Ԃɂ���
    //        lineRenderer.positionCount = 0; // �����\���ɂ���
    //        playermove.moveSpeed = originalSpeed; // �I���W�i���̑��x�ɖ߂�
    //        touchedEnemies.Clear(); // ���X�g����ɂ���
    //    }

    //    if (isDrawingLine)
    //    {
    //        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // �^�O��"Enemy"�̓G�I�u�W�F�N�g���擾

    //        foreach (GameObject enemy in enemies)
    //        {
    //            // �v���C���[�ƓG�̋������v�Z
    //            float distance = Vector3.Distance(player.position, enemy.transform.position);

    //            if (distance < maxDistance)
    //            {
    //                touchedEnemies.Add(enemy.transform);
    //            }
    //            Debug.Log($"Player��{enemy.name}�̋���: {distance}");
    //        }

    //        // ����`�撆���{�^����������Ă���ꍇ�A����`��
    //        // �{�^����������Ă���Ƃ������G�Ƃ̋������`�F�b�N
    //        if (touchedEnemies.Count > 0)
    //        {
    //            // ���̒�����ݒ�
    //            lineRenderer.positionCount = touchedEnemies.Count + 1;
    //            lineRenderer.SetPosition(0, transform.position);

    //            // ���X�g����j�����ꂽ�I�u�W�F�N�g���폜���Ȃ������`��
    //            int currentIndex = 1;
    //            for (int i = 0; i < touchedEnemies.Count;)
    //            {
    //                Transform enemyTransform = touchedEnemies[i];

    //                // Transform�I�u�W�F�N�g���j������Ă��邩�ǂ������`�F�b�N
    //                if (enemyTransform != null)
    //                {
    //                    Vector3 enemyPosition = enemyTransform.position;
    //                    lineRenderer.SetPosition(currentIndex, enemyPosition);
    //                    currentIndex++;
    //                    i++; // ���̓G���`�F�b�N
    //                }
    //                else
    //                {
    //                    // �j�����ꂽ�I�u�W�F�N�g�����X�g����폜
    //                    touchedEnemies.RemoveAt(i);
    //                }
    //            }

    //            // �j�����ꂽ�I�u�W�F�N�g�����X�g����폜������A�]���Ȓ��_���N���A
    //            for (int i = currentIndex; i < lineRenderer.positionCount; i++)
    //            {
    //                lineRenderer.SetPosition(i, Vector3.zero);
    //            }
    //        }
    //    }
    //}
   
}
