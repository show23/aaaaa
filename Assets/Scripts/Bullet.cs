using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;
    private Transform target; // �r�[���̒ǔ��Ώ�
    public float beamSpeed = 100f; // �r�[���̑��x
    public float curveStrength = 1f; // �J�[�u�̋��x

    private int curveDirection = 0; // �J�[�u�����𐧌䂷��ϐ� (0: ��, 1: ��, 2: �E, 3: ������J�[�u)

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // �G�̒ǐՑΏۂ�ݒ�
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Start()
    {
        // �J�[�u�����������_���ɑI��
        curveDirection = Random.Range(0, 6);
    }

    void Update()
    {
        // �ǔ��Ώۂ����݂���ꍇ
        if (target != null)
        {
            // �r�[���̕�����ݒ�i�ǔ��j
            Vector3 direction = (target.position - transform.position).normalized;

            // �J�[�u��K�p
            Vector3 curve = Vector3.zero;

            // �J�[�u�����ɉ����ăJ�[�u��K�p
            switch (curveDirection)
            {
                case 0: // ������J�[�u
                    curve = Vector3.up * curveStrength;
                    break;
                case 1: // �������J�[�u
                    curve = -Vector3.Cross(Vector3.up, direction) * curveStrength;
                    break;
                case 2: // �E�����J�[�u
                    curve = Vector3.Cross(Vector3.up, direction) * curveStrength;
                    break;
                case 3: // ������J�[�u
                    curve = Vector3.up * curveStrength;
                    break;
                case 4:
                    curve = Vector3.up * curveStrength + Vector3.Cross(direction, Vector3.up) * curveStrength;
                    break;
                case 5:
                    curve = Vector3.up * curveStrength - Vector3.Cross(direction, Vector3.up) * curveStrength;
                    break;

                default:
                    break;
            }

            GetComponent<Rigidbody>().velocity = (direction + curve) * beamSpeed;
        }
    }
}
