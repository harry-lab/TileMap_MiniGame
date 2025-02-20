using UnityEngine;

public class NpcTrigger : MonoBehaviour  // MonoBehaviour�� ��ӹ޴� Ŭ���� ����
{
    public GameObject dialogueUI;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // �÷��̾�� �浹 ��
        {
            // ��ȭ UI�� ���� �Լ� ȣ��
            ShowDialogueUI();
        }
    }

    void ShowDialogueUI()
    {
        // ��ȭ UI�� Ȱ��ȭ��Ŵ
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(true);  // UI Ȱ��ȭ
        }
    }

    // �浹�� ������ ��ȭ UI�� ��Ȱ��ȭ�ϴ� ��ɵ� �߰�
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueUI != null)
            {
                dialogueUI.SetActive(false);  // UI ��Ȱ��ȭ
            }
        }
    }
}