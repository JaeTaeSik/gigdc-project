using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordManager : MonoBehaviour
{
    public TMP_InputField passwordInputField; // 비밀번호 TMP_InputField
    public GameObject canvasToClose; // 닫을 캔버스 오브젝트
    [SerializeField] string correctPassword = "0000"; // 올바른 비밀번호 설정
    [SerializeField] float timeset;

    void Update()
    {
        // 엔터 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            VerifyPassword();
        }
    }

    // 비밀번호 검증 및 처리
    public void VerifyPassword()
    {
        if(passwordInputField.text == correctPassword)
        {
            canvasToClose.SetActive(false); // 비밀번호가 맞으면 캔버스 닫기
        }
        else
        {
            StartCoroutine(ShowRetryMessage());
        }
    }

    IEnumerator ShowRetryMessage()
    {
        passwordInputField.text = ""; // 비밀번호 필드 초기화
        TMP_Text placeholderText = passwordInputField.placeholder as TMP_Text;
        if (placeholderText != null)
        {
            placeholderText.text = "Retry"; // 플레이스홀더 텍스트를 "Retry"로 변경
            yield return new WaitForSeconds(timeset); // timeset초 만큼 대기
            placeholderText.text = "Password"; // 플레이스홀더 텍스트를 원래대로 변경
        }
        // 커서와 입력 포커스를 다시 InputField에 설정
        passwordInputField.ActivateInputField();
        passwordInputField.Select();
    }
}
