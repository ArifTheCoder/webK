using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class CartModel
{

    public string InsertProduct(tblCart cart)
    {
        try
        {
            OnlineKitchenDBEntities db = new OnlineKitchenDBEntities();
            db.tblCarts.Add(cart);
            db.SaveChanges();

            return cart.DatePurchased + " was successfully inserted";

        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string UpdateProduct(int id, tblCart cart)
    {
        try
        {
            OnlineKitchenDBEntities db = new OnlineKitchenDBEntities();

            //Fetch object from db
            tblCart p = db.tblCarts.Find(id);

            p.DatePurchased = cart.DatePurchased;
            p.ClientID = cart.ClientID;
            p.Amount = cart.Amount;
            p.IsInCart = cart.IsInCart;
            p.ProductID = cart.ProductID;

            db.SaveChanges();
            return cart.DatePurchased + " was successfully updated";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }

    }

    public string DeleteProduct(int id)
    {
        try
        {
            OnlineKitchenDBEntities db = new OnlineKitchenDBEntities();
            tblCart cart = db.tblCarts.Find(id);

            db.tblCarts.Attach(cart);
            db.tblCarts.Remove(cart);
            db.SaveChanges();

            return cart.DatePurchased + " was successfully deleted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }
}