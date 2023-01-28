using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameManager gameManager;
    public string winner="";
    void OnCollisionEnter(Collision collision)
    {
        winner=(collision.gameObject.name);
        gameManager.UpdateText(winner);
        gameManager.ShowGameOverScreen();
        gameManager.FinishLineHit();
    }
}