using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ElePos : MonoBehaviour
{
    public VisualEffect vfxGraph;
    public Transform targetObject; // ����̕��̂�Transform���w��

    private void Update()
    {
        if (vfxGraph != null && targetObject != null)
        {
            // ����̕��̂̈ʒu���擾
            Vector3 objectPosition = targetObject.position;

            // VFX Graph�̃p�����[�^�Ɉʒu�����Z�b�g
            vfxGraph.SetVector3("ObjectPosition", objectPosition);
        }
    }
}
