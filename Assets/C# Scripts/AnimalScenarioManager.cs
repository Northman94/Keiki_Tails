using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class AnimalScenarioManager : MonoBehaviour
    {
        // Animal Prefabs - Never Destroy!
        [SerializeField]
        private GameObject pigPrefab = null;
        [SerializeField]
        private GameObject catPrefab = null;
        [SerializeField]
        private GameObject dogPrefab = null;

        [SerializeField]
        private GameObject mousePrefab = null;
        [SerializeField]
        private GameObject cowPrefab = null;
        [SerializeField]
        private GameObject horsePrefab = null;

        //GameObject (Clone) to Destroy & Spawn
        GameObject pigClone;
        GameObject catClone;
        GameObject dogClone;

        GameObject mouseClone;
        GameObject cowClone;
        GameObject horseClone;


        //Tags List
        private string pigTag = "pigTag";
        private string catTag = "catTag";
        private string dogTag = "dogTag";

        private string mouseTag = "mouseTag";
        private string cowTag = "cowTag";
        private string horseTag = "horseTag";

        private int animalRotationVar = 5;

        private GameObject currentAnimal;

        void Start()
        {
            AnimalRotation();
        }
        

        public void AnimalRotation()
        {
            pigClone = pigPrefab;
            catClone = catPrefab;
            dogClone = dogPrefab;

            mouseClone = mousePrefab;
            cowClone = cowPrefab;
            horseClone = horsePrefab;


            switch (animalRotationVar)
            {
                case 0:
                    Creation(pigClone, pigTag);
                    break;
                case 1:
                    Creation(catClone, catTag);
                    break;
                case 2:
                    Creation(dogClone, dogTag);
                    break;
                case 3:
                    Creation(mouseClone, mouseTag);
                    break;
                case 4:
                    Creation(cowClone, cowTag);
                    break;
                case 5:
                    Creation(horseClone, horseTag);
                    break;
                default:
                    break;
            }
        }

        public void Creation(GameObject _animalToCreate, string _rightAnimalTag)
        {
            Instantiate(_animalToCreate, new Vector3(0f, 0f, -5f), Quaternion.identity);

            //Setting right animal in TailsManager
            TailsManager ttm = new TailsManager();
            ttm.RightAnimalTagSetup(_rightAnimalTag);
            


            currentAnimal = _animalToCreate;

            //Play PigQuestion

            if (_animalToCreate == horseClone)
            {
                animalRotationVar = 0;
            }
            else
            {
                animalRotationVar++;
            }
        }

        public void AnimalDestruction()
        {
            Debug.Log("You'll be destroyed");

            Destroy(currentAnimal, 30f);

            TailsManager tlsd = new TailsManager();
            tlsd.TailsPlacement();
        }

    }
}