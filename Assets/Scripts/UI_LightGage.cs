using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LightGage : MonoBehaviour
{
    [SerializeField]
    Image image1;
    Image image2;

    private float playerDistance;
    private bool gageIncrease = false;
    private bool gaugeVisible = false;
    private float distanceMoved;
    public float fillSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        image2 = GetComponent<Image>();
        image2.fillAmount = 0f; // �Q�[�W���[������X�^�[�g
        image2.fillOrigin = (int)Image.OriginHorizontal.Left; // �Q�[�W�̑������E����
        image1.color = new Color(1f, 1f, 1f, 0f); // �ŏ��͓���

        // �Q�[�W���ŏ��͔�\����
        image2.enabled = false;
        image1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            distanceMoved += 1;
        }
        

        // �v���C���[�̋����ɉ�����image2.fillAmount�𑝉�
        float maxDistance = 100.0f; // ��Ƃ��čő勗����100�Ƃ��܂�
        float fillAmount = distanceMoved / maxDistance;

        // �Q�[�W���������鑬�x�𒲐�����W����ݒ�
        
        image2.fillAmount = fillAmount * fillSpeed;

        // �Q�[�W�����ȏ㑝��������F��\��
        if (image2.fillAmount > 0.01f && !gaugeVisible)
        {
            gaugeVisible = true;
            image2.enabled = true;
            image1.enabled = true;
        }
    }
}
