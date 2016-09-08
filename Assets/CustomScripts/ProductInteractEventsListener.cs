    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    namespace VRTK
{
    public class ProductInteractEventsListener : MonoBehaviour
    {
        // Variables for Transition Elements and/or Components
        MediaPlayerController mediaPlayerController;
        FogFader fogFader;
        RendererEnabler retailPeripheryEnabler;
        ProductInfo productInfo;
        
        // Use this for initialization
        void Start()
        {
            productInfo = GetComponent<ProductInfo>();

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
            switch (productInfo.type)
            {
                case ProductInfo.Type.AvocadoProduct:
                    break;
                case ProductInfo.Type.CarVisorProduct:
                    break;
                case ProductInfo.Type.NailPolishProduct:
                    break;
                case ProductInfo.Type.UniverseBluRayProduct:
                    break;
                case ProductInfo.Type.JetLagPillProduct:
                    break;
                case ProductInfo.Type.BalanceBarProduct:
                    break;
                case ProductInfo.Type.CandleProduct:
                    break;
            }
        }

        void DoInteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
        {
            //print(e.interactingObject + "UNTOUCHED");
            switch (productInfo.type)
            {
                case ProductInfo.Type.AvocadoProduct:
                    break;
                case ProductInfo.Type.CarVisorProduct:
                    break;
                case ProductInfo.Type.NailPolishProduct:
                    break;
                case ProductInfo.Type.UniverseBluRayProduct:
                    break;
                case ProductInfo.Type.JetLagPillProduct:
                    break;
                case ProductInfo.Type.BalanceBarProduct:
                    break;
                case ProductInfo.Type.CandleProduct:
                    break;
            }
        }
        
        //Grabbed
        void DoInteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            Debug.Log(productInfo.ToString() + "Grabbed By" + e.interactingObject.ToString());

            if (e.interactingObject != null)
            { 
            switch (productInfo.type)
            {
                case ProductInfo.Type.AvocadoProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    Invoke("FadeFogOut", 1.5f);
                    mediaPlayerController.PlayScene("AvocadoProduct");
                    break;
                case ProductInfo.Type.CarVisorProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductInfo.Type.NailPolishProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductInfo.Type.UniverseBluRayProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductInfo.Type.JetLagPillProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductInfo.Type.BalanceBarProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
                case ProductInfo.Type.CandleProduct:
                    retailPeripheryEnabler.IntervalDisableTargets();
                    break;
            }
            }
        }

        //Invoked methods for Grabbed event
        void FadeFogOut()
        {
            fogFader.FadeFogOut(1.5f);
        }
        
        //Ungrabbed
        void DoInteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            print(productInfo.ToString() + "Ungrabbed By" + e.interactingObject.ToString());
            switch (productInfo.type)
            {
                case ProductInfo.Type.AvocadoProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    fogFader.FadeFogIn(1.5f);
                    mediaPlayerController.PauseScene("AvocadoProduct");
                    break;
                case ProductInfo.Type.CarVisorProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductInfo.Type.NailPolishProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductInfo.Type.UniverseBluRayProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductInfo.Type.JetLagPillProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductInfo.Type.BalanceBarProduct:
                    retailPeripheryEnabler.IntervalEnableTargets();
                    break;
                case ProductInfo.Type.CandleProduct:
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