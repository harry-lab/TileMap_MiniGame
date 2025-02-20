using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    public string miniGame = "MiniGame";

    private void OnTriggerEnter2D(Collider2D other) // 2D 물리 적용
    {
        if (other.CompareTag("Player"))  // 플레이어가 트리거에 들어가면
        {
            SceneManager.LoadScene(miniGame);
        }
    }
}
