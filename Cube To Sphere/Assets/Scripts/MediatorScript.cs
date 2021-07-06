using UnityEngine;

public class MediatorScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pointCreator;
    [SerializeField] private GameObject uiCounter;

    private CubePathFounder cube;
    private PointsGeneration creator;
    private CounterScript pointCounter;
    void Start()
    {
       cube = player.GetComponent<CubePathFounder>();
       creator = pointCreator.GetComponent<PointsGeneration>();
       pointCounter = uiCounter.GetComponent<CounterScript>();
       creator.OnPointCreate.AddListener(cube.AddToList);
       cube.OnPointsAdd.AddListener(pointCounter.AddToCounter);
    }

    private void OnDisable()
    {
        creator.OnPointCreate.RemoveAllListeners();
        cube.OnPointsAdd.RemoveAllListeners();

    }
  
}
