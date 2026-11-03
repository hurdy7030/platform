using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    private bool finished;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.collider.CompareTag("Finish"))
        {
            finished = true;
        }
        
    }

    void OnGUI()
    {
        if (finished)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = 36;
            style.alignment = TextAnchor.MiddleCenter;
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "congratulations！", style);
        }
    }
}
