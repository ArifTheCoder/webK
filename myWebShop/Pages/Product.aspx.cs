﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        //get selected product's data
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductModel productModel = new ProductModel();
            tblProduct product = productModel.GetProduct(id);

            //fill page with data
            lblPrice.Text = "Price per kg: <br/>€ " + product.Price;
            lblTitle.Text = product.Name;
            lblDescription.Text = product.Description;
            lblItemNr.Text = id.ToString();
            imgProduct.ImageUrl = "~/Images/Products/" + product.Image;

            //Fill amount dropdownlist with number 1 - 10
            int[] amount = Enumerable.Range(1, 10).ToArray();
            ddlAmount.DataSource = amount;
            ddlAmount.AppendDataBoundItems = true;
            ddlAmount.DataBind();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            string clientId = "-1";
            int id = Convert.ToInt32(Request.QueryString["id"]);
            int amount = Convert.ToInt32(ddlAmount.SelectedValue);

            tblCart cart = new tblCart
            {
                Amount = amount,
                ClientID = clientId,
                DatePurchased = DateTime.Now,
                IsInCart = true,
                ProductID = id
            };

            CartModel model = new CartModel();
            lblResult.Text = model.InsertProduct(cart);
        }
    }
}