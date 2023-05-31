using System.Collections;
using UnityEngine;

public class PlayerObstaclesChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            print("Ты серьёзно проиграл? Нет слоф...");
            GameManager.Instance.EndGame();
        }
    }
}