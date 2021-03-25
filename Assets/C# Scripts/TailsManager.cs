using System.Collections;
using UnityEngine;

//Script dedicated to Tails spawn & movement
namespace Interaction
{
    public class TailsManager : MonoBehaviour
    {
        private static string rightAnimalTagString;
        //Should be static, becuse in other Classes there is
        // two this class objects(instances)


        //Original Prefabs - Never Destroy!
        [SerializeField]
        private GameObject mouseTail = null;
        [SerializeField]
        private GameObject horseTail = null;
        [SerializeField]
        private GameObject dogTail = null;

        [SerializeField]
        private GameObject pigTail = null;
        [SerializeField]
        private GameObject catTail = null;
        [SerializeField]
        private GameObject cowTail = null;

        //GameObject (Clone) to Destroy & Spawn
        GameObject mouseTailClone;
        GameObject horseTailClone;
        GameObject dogTailClone;

        GameObject pigTailClone;
        GameObject catTailClone;
        GameObject cowTailClone;


        private GameObject currentTailSelected;

        private static bool allTailsToSpawn = false;
        private static bool allTailsToDestroy = false;




        //Tail Tags List
        //private string mouseTailTag = "mouseTagTail";
        //private string horseTailTag = "horseTagTail";
        //private string dogTailTag = "dogTagTail";

        //private string pigTailTag = "pigTagTail";
        //private string catTailTag = "catTagTail";
        //private string cowTailTag = "cowTagTail";


        private void Start()
        {
            FirstTimeObjectCreation();

            StartCoroutine(TailsPlacement());
        }

        private void FirstTimeObjectCreation()
        {
            mouseTailClone = mouseTail;
            Instantiate(mouseTailClone, new Vector3(-9.21f, 3.07f, 3f), Quaternion.identity);
            horseTailClone = horseTail;
            Instantiate(horseTailClone, new Vector3(-7.85f, -0.05f, 3f), Quaternion.identity);
            dogTailClone = dogTail;
            Instantiate(dogTailClone, new Vector3(-9.93f, -2.36f, 3f), Quaternion.identity);

            pigTailClone = pigTail;
            Instantiate(pigTailClone, new Vector3(8.67f, 2.69f, 3f), Quaternion.identity);
            catTailClone = catTail;
            Instantiate(catTailClone, new Vector3(10.05f, -0.42f, 3f), Quaternion.identity);
            cowTailClone = cowTail;
            Instantiate(cowTailClone, new Vector3(8.75f, -2.09f, 3f), Quaternion.Euler(0, 0, 64));
            //Interacting with Collider, not Sprite
        }



        //Not used Tails deletion & New Pack spawn
        public IEnumerator TailsPlacement()
        {         
            while (true)
            {
                Debug.Log("Iteration");

                if (allTailsToSpawn)
                {
                    Debug.Log("Creatioooooooooooooooon");


                    mouseTailClone.SetActive(true);
                    horseTailClone.SetActive(true);
                    dogTailClone.SetActive(true);

                    pigTailClone.SetActive(true);
                    catTailClone.SetActive(true);
                    cowTailClone.SetActive(true);



                    allTailsToSpawn = false;
                    //allTailsToDestroy = false;                    
                }


                if (allTailsToDestroy)
                {
                    Debug.Log("Destructuionnnnnnnnnnnnn");

                    mouseTailClone.SetActive(false);
                    horseTailClone.SetActive(false);
                    dogTailClone.SetActive(false);

                    pigTailClone.SetActive(false);
                    catTailClone.SetActive(false);
                    cowTailClone.SetActive(false);

                    allTailsToSpawn = true;
                    allTailsToDestroy = false;
                }


                yield return new WaitForSeconds(5);
            }
        }
        

        // TailTag & AnimalTag matching
        //Called out of FingerAndMouseInteraction
        public void ObjectTagCheck(string _tailtag, GameObject _selectedObjName)
        {
            currentTailSelected = _selectedObjName;

            if (_tailtag.Contains(rightAnimalTagString))
            {
                /*
                if (_tailtag == )
                {

                }
                */


                Debug.Log("Correct " + rightAnimalTagString.ToString() + " == " + _tailtag);

                //Play Mother_C_A

                currentTailSelected.SetActive(false);

                allTailsToDestroy = true;

                //Destroy Animal in AnimalScenarioManager & trigger NEXT
                //AnimalScenarioManager asdf = new AnimalScenarioManager();
                //asdf.AnimalDestruction();
            }
            else
            {
                //Wrong tail Destruction
                Debug.Log("Wrong " + rightAnimalTagString.ToString() + " != " + _tailtag);

                //Play MotherI_A

                currentTailSelected.SetActive(false);
            }           
        }

     
        //Called out AnimalScenarioManager
        public void RightAnimalTagSetup(string _animalTag)
        {
            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            rightAnimalTagString = _animalTag;

            if (rightAnimalTagString != null)
            {
                Debug.Log("+++++++++++++++++++++++++ " + rightAnimalTagString);
            }
            
        }
    }
}

