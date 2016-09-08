

//For sending "add product" calls to the shopping cart site http://www.institutefornewfeeling.com/store 


using UnityEngine;
using System.Collections;

public class ShoppingCartWebCaller : MonoBehaviour {

    public string addAvocadoProductURL = "http://www.institutefornewfeeling.com/functions/storeapi.php?action=add&product=avocado";
    public string addCarVisorProductURL = "http://www.institutefornewfeeling.com/functions/storeapi.php?action=add&product=visor";
    public string addNailPolishProductURL = "http://www.institutefornewfeeling.com/functions/storeapi.php?action=add&product=nailpolish";
    public string addUniverseBlueRayProductURL = "http://www.institutefornewfeeling.com/functions/storeapi.php?action=add&product=universe";
    public string addJetLagPillProductURL = "http://www.institutefornewfeeling.com/functions/storeapi.php?action=add&product=jetlagpill";
    public string addBalanceBarProductURL = "http://www.institutefornewfeeling.com/functions/storeapi.php?action=add&product=balancebar";
    public string addCandleProductURL = "http://www.institutefornewfeeling.com/functions/storeapi.php?action=add&product=candle";
    public string currentAddProdURL;

    public void IncreaseCartQuantityWebCall (ProductInfo pi)
    {
        switch (pi.type)
        {
            case ProductInfo.Type.AvocadoProduct:
                currentAddProdURL = addAvocadoProductURL;
                break;
            case ProductInfo.Type.CarVisorProduct:
                currentAddProdURL = addCarVisorProductURL;
                break;
            case ProductInfo.Type.NailPolishProduct:
                currentAddProdURL = addNailPolishProductURL;
                break;
            case ProductInfo.Type.UniverseBluRayProduct:
                currentAddProdURL = addUniverseBlueRayProductURL;
                break;
            case ProductInfo.Type.JetLagPillProduct:
                currentAddProdURL = addJetLagPillProductURL;
                break;
            case ProductInfo.Type.BalanceBarProduct:
                currentAddProdURL = addBalanceBarProductURL;
                break;
            case ProductInfo.Type.CandleProduct:
                currentAddProdURL = addCandleProductURL;
                break;
        }
        Debug.Log(currentAddProdURL);
        StartCoroutine("SendProductCall");
	}
    
    IEnumerator SendProductCall()
    {
        WWW postResult = new WWW(currentAddProdURL);
        yield return postResult;
        Debug.Log("SendProductCall() Response:" + postResult.text);
    }
}