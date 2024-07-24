using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{

    public GameObject pipe;
    public float height;
    public float maxTime;
    private float timer = 0;

    private GameController gameController;
    private int scoreIncrementCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameObject newPipe = Instantiate(pipe);
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height,height),0);
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseLevel();
        if(timer > maxTime)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height,height),0);
            Destroy(newPipe, 20f);
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void IncreaseLevel()
    {
        // Verifique se o score aumentou em múltiplos de 10
        if (gameController.score >= 5 * (scoreIncrementCount + 1))
        {
            // Aumente o contador de incremento de score
            scoreIncrementCount++;
            
            // Verifique se o maxTime ainda pode ser reduzido
            if (maxTime > 1.0f)
            {
                // Reduza o maxTime em 0.2
                maxTime -= 0.2f;
                height += 0.1f;
                
                // Certifique-se de que o maxTime não fique abaixo de 1.0
                if (maxTime < 1.0f)
                {
                    maxTime = 1.0f;
                    height = 3.5f;
                }
            }
        }
    }
}
