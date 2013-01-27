using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : MonoBehaviour
{
    public TriggerType TriggerType = TriggerType.ModuleInstanciator;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Character>() != null)
        {
            if (this.TriggerType == global::TriggerType.Jump)
            {
                InputController.Instance.Jump();
            }
            else if (this.TriggerType == global::TriggerType.ModuleInstanciator)
            {
                GameObject gameLogic = GameObject.Find("GameLogic");

                List<Module> listModule = GetListFromArray<Module>(gameLogic.GetComponents<Module>());
                List<DifficultyLevel> listDifficultyLevel = GetListFromArray<DifficultyLevel>(gameLogic.GetComponents<DifficultyLevel>());

                DifficultyLevel currentDifficultyLevel = listDifficultyLevel.Find(level => level.Difficulty == Repository.Instance.CurrentDifficulty);

                System.Random rnd = new System.Random();
                int percentChoosed = rnd.Next(0, 100);


                Debug.Log("Percent choosed : " + percentChoosed.ToString());


                int count = currentDifficultyLevel.NiveauMinimalVie.FindAll(niveau => niveau <= Repository.Instance.Life).Count;
                List<int> listIndex = new List<int>();
                List<int> listCoeff = new List<int>();
                int totalCoeff = 0;

                for (int i = 0; i < currentDifficultyLevel.NiveauMinimalVie.Count; i++)
                {
                    if (currentDifficultyLevel.NiveauMinimalVie[i] <= Repository.Instance.Life)
                    {
                        listIndex.Add(i);
                        listCoeff.Add(100 - currentDifficultyLevel.NiveauMinimalVie[i]);
                        totalCoeff += 100 - currentDifficultyLevel.NiveauMinimalVie[i];
                    }
                }

                int indexChoosed = -1;

                for (int i = 0; i < listIndex.Count; i++)
                {
                    int curValue = listCoeff[i] / totalCoeff;
                    int prevValue = 0;

                    Debug.Log("prev coeff : " + prevValue.ToString());
                    Debug.Log("cur coeff : " + curValue.ToString());

                    if (i > 0)
                        prevValue = listCoeff[i - 1] / totalCoeff;

                    if (prevValue <= percentChoosed && curValue <= percentChoosed)
                    {
                        indexChoosed = i;
                        break;
                    }

                }

                if (indexChoosed == -1)
                    indexChoosed = 0;

                Repository.Instance.CurrentDifficulty = currentDifficultyLevel.DifficultyDependency[indexChoosed];

                List<Module> ListModuleForNextDifficulty = listModule.FindAll(module => module.Difficulty == Repository.Instance.CurrentDifficulty);

                if (ListModuleForNextDifficulty != null && ListModuleForNextDifficulty.Count > 0)
                {
                    indexChoosed = rnd.Next(ListModuleForNextDifficulty.Count);
                    Module nextModule = ListModuleForNextDifficulty[indexChoosed];

                    Debug.Log("Next Module : " + nextModule.Nom);


                    if (nextModule.ModulePrefab != null)
                    {

                        Vector3 vec = new Vector3(Repository.Instance.NbModule * 38 + Repository.Instance.Vecteur.x, Repository.Instance.Vecteur.y, Repository.Instance.Vecteur.z);

                        Repository.Instance.NbModule++;


                        Instantiate(nextModule.ModulePrefab, vec, Quaternion.identity);
                    }
                }
            }
        }
    }


    public List<T> GetListFromArray<T>(T[] tab)
    {
        List<T> list = new List<T>();

        foreach (T item in tab)
        {
            list.Add(item);
        }

        return list;
    }
}

public enum TriggerType
{
    Jump,
    ModuleInstanciator
}
