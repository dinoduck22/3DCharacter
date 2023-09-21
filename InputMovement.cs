using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    public float moveSpeed; //이동 크기
    public Animator animator; //애니메이터 컴포넌트 접근 참조

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //수평 방항키 값 왼 -1, 오 +1, 무입력 0 
        float v = Input.GetAxis("Vertical"); //수직 방향키 값 아래 -1, 위 +1, 무입력 0

        //방향 벡터 정보 생성
            //Vector math Unity 개념 이해 필요
            //캐릭터의 8개의 방향성인 방향 Vector (x, y, z)
            //normalized 정규화
        Vector3 normalDirection = new Vector3(h, 0f, v).normalized; 

        //좌표값으로 이동
        transform.position += (normalDirection * moveSpeed * Time.deltaTime);

        //애니메이터 컴포넌트의 Float값을 "Speed" 변수로 값을 넘겨라 
            //magnitude 벡터의 길이 
        animator.SetFloat("Speed", normalDirection.magnitude);

        //방향 키를 누른 곳으로 캐릭터가 회전
        transform.LookAt(transform.position + normalDirection);
    }
}
