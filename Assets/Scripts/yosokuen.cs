using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yosokuen : MonoBehaviour
{
    PlayerManager playerManager;
    // �^�[�Q�b�g�ƂȂ�I�u�W�F�N�g��Transform�R���|�[�l���g���擾
    private Transform targetTransform;
    private KeyCode hikiyosae;
    private KeyCode attack;
    // public float attackSize = 0.0f;
    private float range;
    //public bool attckOk;
    //public KeyCode attractionKey = KeyCode.E; // �����񂹂�L�[
    // �I�u�W�F�N�g�̏����T�C�Y�ƐV�����T�C�Y��ݒ�
    private Vector3 initialSize;
    //public Vector3 newSize = new Vector3(2.0f, 2.0f, 2.0f); // ��Ƃ���2�{�̑傫���ɕύX


    // �T�C�Y�ύX�̑��x
    //public float sizeChangeSpeed = 1.0f;

    private bool isResizing = false;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        // �^�[�Q�b�g�I�u�W�F�N�g�𖼑O�Ō������A����Transform���擾
        targetTransform = GameObject.Find("�g�[���X").transform;

        // �^�[�Q�b�g�I�u�W�F�N�g�̏����T�C�Y��ۑ�
        initialSize = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void Update()
    {

        //otamesi = PlayerAttractor.instance.attractionKey;
        attack = playerManager.attackKey;
        range = playerManager.interactionRange * 0.08f;
        if(Input.GetKey(attack))
        {
            isResizing = true;
        }
        // ���Z�b�g����ꍇ�i�����T�C�Y�ɖ߂��j
        else
        {
            isResizing = false;
            targetTransform.localScale = initialSize;
        }

        // �{�^����������Ă���ԂɃT�C�Y��ύX����
        if (isResizing)
        {
            // �V�����T�C�Y�Ɍ������ď��X�ɕύX
            targetTransform.localScale = new Vector3(range,range,range);
            //Debug.Log(targetTransform.localScale);

            //if (targetTransform.localScale == newSize)
            //{
            //    attckOk = true;
            //}
        }
    }


}
