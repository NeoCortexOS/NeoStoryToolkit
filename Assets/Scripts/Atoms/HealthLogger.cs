
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(menuName = "Unity Atoms/RestartLevelOnDeath")]
public class HealthLogger : IntAction
{
    public override void Do(int health)
    {
        Debug.Log("<3: " + health);
 /*       if (health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }*/
    }
}