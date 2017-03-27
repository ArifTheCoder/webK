using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ProductTypeModel
{
    public string InsertProduct(tblProductType productType)
    {
        try
        {
            OnlineKitchenDBEntities db = new OnlineKitchenDBEntities();
            db.tblProductTypes.Add(productType);
            db.SaveChanges();

            return productType.Name + " was successfully inserted";

        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string UpdateProduct(int id, tblProductType productType)
    {
        try
        {
            OnlineKitchenDBEntities db = new OnlineKitchenDBEntities();

            //Fetch object from db
            tblProductType p = db.tblProductTypes.Find(id);

            p.Name = productType.Name;
           

            db.SaveChanges();
            return productType.Name + " was successfully updated";
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
            tblProductType productType = db.tblProductTypes.Find(id);

            db.tblProductTypes.Attach(productType);
            db.tblProductTypes.Remove(productType);
            db.SaveChanges();

            return productType.Name + " was successfully deleted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }
}