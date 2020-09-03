using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float slowness = 10f;
    public float restartTime =1f;
    bool gameHasEnded = false;
    public void EndGame()
    {
        if(gameHasEnded==false){
            gameHasEnded=true;
            StartCoroutine(Restart());
        }
    }
    IEnumerator Restart()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        yield return new WaitForSeconds(restartTime / slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        
        //After 1 second
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
