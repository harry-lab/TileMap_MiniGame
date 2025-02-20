using UnityEngine;

public class NpcTrigger : MonoBehaviour  // MonoBehaviour를 상속받는 클래스 정의
{
    public GameObject dialogueUI;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 플레이어와 충돌 시
        {
            // 대화 UI를 띄우는 함수 호출
            ShowDialogueUI();
        }
    }

    void ShowDialogueUI()
    {
        // 대화 UI를 활성화시킴
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(true);  // UI 활성화
        }
    }

    // 충돌이 끝나면 대화 UI를 비활성화하는 기능도 추가
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueUI != null)
            {
                dialogueUI.SetActive(false);  // UI 비활성화
            }
        }
    }
}