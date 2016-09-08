using UnityEngine;
using System.Collections;

public class ShoppingCartComponent : MonoBehaviour {

    static int avocadoQuantity = 0;
    static int carVisorQuantity = 0;
    static int nailPolishQuantity = 0;
    static int universeBluRayQuantity = 0;
    static int jetLagPillQuantity = 0;
    static int balanceBarQuantity = 0;
    static int candleQuantity = 0;

    bool canAddToCart = false;
    int addToCartPushCount = -1;

    ShoppingCartWebCaller shoppingCartWebCaller;

    void Start ()
    {
        shoppingCartWebCaller = GetComponent<ShoppingCartWebCaller>();
    }


    public void IncreaseCartQuantity(ProductInfo prodInfo)
    {
        shoppingCartWebCaller.IncreaseCartQuantityWebCall(prodInfo);
            switch (prodInfo.type)
            {
                case ProductInfo.Type.AvocadoProduct:
                    avocadoQuantity++;
                    Debug.Log("+1 " + prodInfo.type + "  Local Quantity:" + avocadoQuantity);
                    break;
                case ProductInfo.Type.CarVisorProduct:
                    carVisorQuantity++;
                    Debug.Log("+1 " + prodInfo.type + "  Local Quantity:" + carVisorQuantity);
                    break;
                case ProductInfo.Type.NailPolishProduct:
                    nailPolishQuantity++;
                    Debug.Log("+1 " + prodInfo.type + "  Local Quantity:" + nailPolishQuantity);
                    break;
                case ProductInfo.Type.UniverseBluRayProduct:
                    universeBluRayQuantity++;
                    Debug.Log("+1 " + prodInfo.type + "  Local Quantity:" + universeBluRayQuantity);
                    break;
                case ProductInfo.Type.JetLagPillProduct:
                    jetLagPillQuantity++;
                    Debug.Log("+1 " + prodInfo.type + "  Local Quantity:" + jetLagPillQuantity);
                    break;
                case ProductInfo.Type.BalanceBarProduct:
                    balanceBarQuantity++;
                    Debug.Log("+1 " + prodInfo.type + "  Local Quantity:" + balanceBarQuantity);
                    break;
                case ProductInfo.Type.CandleProduct:
                    candleQuantity++;
                    Debug.Log("+1 " + prodInfo.type + "  Local Quantity:" + candleQuantity);
                    break;
            }
        }
    }

    /*
    public void TurnCanAddToCartTimerOn()
    {
        canAddToCart = true;
        //first float is delay, second float is repeating interval
        InvokeRepeating("CanAddTimer", 2.0f, 1.0f);
    }

    public void TurnCanAddToCartTimerOff()
    {
        CancelInvoke("CanAddTimer");
        canAddToCart = false;
    }
    */







