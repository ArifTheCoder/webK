using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ProductModel
{
    public string InsertProduct(tblProduct product)
    {
        try
        {
            OnlineKitchenDBEntities db = new OnlineKitchenDBEntities();
            db.tblProducts.Add(product);
            db.SaveChanges();

            return product.Name + " was successfully inserted";

        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }
	
    public string UpdateProduct(int id, tblProduct product)
    {
        try
        {
            OnlineKitchenDBEntities db = new OnlineKitchenDBEntities();

            //Fetch object from db
            tblProduct p = db.tblProducts.Find(id);

            p.Name = product.Name;
            p.Price = product.Price;
            p.TypeId = product.TypeId;
            p.Description = product.Description;
            p.Image = product.Image;

            db.SaveChanges();
            return product.Name + " was successfully updated";
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
            tblProduct product = db.tblProducts.Find(id);

            db.tblProducts.Attach(product);
            db.tblProducts.Remove(product);
            db.SaveChanges();

            return product.Name + " was successfully deleted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public tblProduct GetProduct(int id)
    {
        try
        {
            using (OnlineKitchenDBEntities db = new OnlineKitchenDBEntities())
            {
                tblProduct product = db.tblProducts.Find(id);
                return product;
            }

        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<tblProduct> GetAllProducts()
    {
        try
        {
            using (OnlineKitchenDBEntities db = new OnlineKitchenDBEntities())
            {
                List<tblProduct> products = (from x in db.tblProducts
                                             select x).ToList();
                return products;
            }

        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<tblProduct> GetProductsByType(int typeId)
    {

        try
        {
            using (OnlineKitchenDBEntities db = new OnlineKitchenDBEntities())
            {
                List<tblProduct> products = (from x in db.tblProducts
                                             where x.TypeId == typeId
                                             select x).ToList();
                return products;
            }

        }
        catch (Exception)
        {
            return null;
        }
    }
}