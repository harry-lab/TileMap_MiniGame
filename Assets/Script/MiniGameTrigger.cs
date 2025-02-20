using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    public string miniGame = "MiniGame";

    private void OnTriggerEnter2D(Collider2D other) // 2D ���� ����
    {
        if (other.CompareTag("Player"))  // �÷��̾ Ʈ���ſ� ����
        {
            SceneManager.LoadScene(miniGame);
        }
    }
}
