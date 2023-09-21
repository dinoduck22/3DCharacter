using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    public float moveSpeed; //�̵� ũ��
    public Animator animator; //�ִϸ����� ������Ʈ ���� ����

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //���� ����Ű �� �� -1, �� +1, ���Է� 0 
        float v = Input.GetAxis("Vertical"); //���� ����Ű �� �Ʒ� -1, �� +1, ���Է� 0

        //���� ���� ���� ����
            //Vector math Unity ���� ���� �ʿ�
            //ĳ������ 8���� ���⼺�� ���� Vector (x, y, z)
            //normalized ����ȭ
        Vector3 normalDirection = new Vector3(h, 0f, v).normalized; 

        //��ǥ������ �̵�
        transform.position += (normalDirection * moveSpeed * Time.deltaTime);

        //�ִϸ����� ������Ʈ�� Float���� "Speed" ������ ���� �Ѱܶ� 
            //magnitude ������ ���� 
        animator.SetFloat("Speed", normalDirection.magnitude);

        //���� Ű�� ���� ������ ĳ���Ͱ� ȸ��
        transform.LookAt(transform.position + normalDirection);
    }
}
