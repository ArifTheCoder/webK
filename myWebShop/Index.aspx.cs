using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        //Get a list of all products in DB
        ProductModel productModel = new ProductModel();
        List<tblProduct> products = productModel.GetAllProducts();

        //Make sure products exist in the database
        if (products != null)
        {
            //Create a new Panel with a ImageButton and 2 labels for each product
            foreach (tblProduct product in products)
            {
                Panel productPanel = new Panel();
                ImageButton imageButton = new ImageButton();
                Label lblName = new Label();
                Label lblPrice = new Label();

                //Set childcontrols properties
                imageButton.ImageUrl = "~/Images/Products/" + product.Image;
                imageButton.CssClass = "productImage";
                imageButton.PostBackUrl = "~/Pages/Product.aspx?id=" + product.Id;

                lblName.Text = product.Name;
                lblName.CssClass = "productName";

                lblPrice.Text = "€ " + product.Price;
                lblPrice.CssClass = "productPrice";

                //Add child control to Panel
                productPanel.Controls.Add(imageButton);
                productPanel.Controls.Add(new Literal { Text = "<br />" });
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(new Literal { Text = "<br />" });
                productPanel.Controls.Add(lblPrice);

                //Add dynamic panels to static parent panel
                pnlProducts.Controls.Add(productPanel);
            }
        }
        else
        {
            //No products found
            pnlProducts.Controls.Add(new Literal { Text = "No products found!" });
        }
    }
}