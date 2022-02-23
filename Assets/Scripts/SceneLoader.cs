<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame(){
        SceneManager.LoadScene ("GameScene");
    }

    public void GameOver(){
        SceneManager.LoadScene ("GameOver");
    }

    // y aquí continuaran el resto de load scenes
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame(){
        SceneManager.LoadScene ("GameScene");
    }

    public void GameOver(){
        SceneManager.LoadScene ("GameOver");
    }

    // y aquí continuaran el resto de load scenes
}
>>>>>>> Stashed changes
