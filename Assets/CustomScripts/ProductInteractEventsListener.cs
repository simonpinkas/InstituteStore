/// <summary>
/// This script is to be attached to Product Gameobjects and controls mainly scene transitions, 
/// with different 'Transition In/Out' behaviors per Product Type.
/// 
/// The TransitionPeriphery() function is used in all product transitions for transitioning
/// elements in the surrounding areas outside the Vive area boundaries.
/// </summary>

    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    namespace VRTK
{
    public class ProductInteractEventsListener : MonoBehaviour
    {

        // Select product type
        public ProductType productType;
        public enum ProductType
        {
            AvocadoProduct,//1
            CarVisorProduct,//2
            NailPolishProduct,//3
            UniverseBluRayProduct,//4
            JetLagPillProduct,//5
            BalanceBarProduct,//6
            CandleProduct//7
        }

        // Variables for Transition Elements and/or Components
        MediaPlayerController mediaPlayerController;
        FogFader fogFader;
        RendererEnabler retailPeripheryEnabler;


        // Use this for initialization
        void Start()
        {

            // Initialization of Variables for Transition Elements and/or Components
            mediaPlayerController = GameObject.Find("AVPro Video Media Player").GetComponent<MediaPlayerController>();
            fogFader = mediaPlayerController.gameObject.GetComponent<FogFader>();
            retailPeripheryEnabler = GameObject.FindGameObjectWithTag("RetailPeriphery").GetComponent<RendererEnabler>();


            //Setup controller event listeners
            GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += DoInteractableObjectTouched;
            GetComponent<VRTK_InteractableObject>().InteractableObjectUntouched += DoInteractableObjectUntouched;

            GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += DoInteractableObjectGrabbed;
            GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += DoInteractableObjectUngrabbed;

            GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += DoInteractableObjectUsed;
            GetComponent<VRTK_InteractableObject>().InteractableObjectUnused += DoInteractableObjectUnused;

        }


        // Product interaction events
        void DoInteractableObjectTouched(object sender, InteractableObjectEventArgs e)
        {
            //print(e.interactingObject + "TOUCHED");
        }

        void DoInteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
        {
            //print(e.interactingObject + "UNTOUCHED");
        }


        //Grabbed
        void DoInteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            print("GRABBED:" + "Geo:" + e.interactingObject.ToString() + "Type:" + productType.ToString());
            
            switch (productType)
            {
                case ProductType.AvocadoProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    fogFader.FadeFogOut(1.5f);
                    mediaPlayerController.PlayScene("AvocadoProduct");
                    break;
                case ProductType.CarVisorProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductType.NailPolishProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductType.UniverseBluRayProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductType.JetLagPillProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductType.BalanceBarProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductType.CandleProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
            }
        }


        //Ungrabbed
        void DoInteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            print("UNGRABBED:" + "Geo:" + e.interactingObject.ToString() + "Type:" + productType.ToString());
            switch (productType)
            {
                case ProductType.AvocadoProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    fogFader.FadeFogIn(1.5f);
                    break;
                case ProductType.CarVisorProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductType.NailPolishProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductType.UniverseBluRayProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductType.JetLagPillProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductType.BalanceBarProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductType.CandleProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
            }
        }


        void DoInteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {

        }

        void DoInteractableObjectUnused(object sender, InteractableObjectEventArgs e)
        {

        }

    }
        
}

