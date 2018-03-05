using SearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SearchApp
{
	public partial class MainPage : ContentPage
	{
	    private List<ShopItem> ShopItems;
		public MainPage()
		{
			InitializeComponent();
            ShopItems = new List<ShopItem> {
                new ShopItem {Name = "Gucci Hand Bag Light Brown" , Status ="Almost New" , Price = "3000.00"  , ImgSource = "https://cdnd.lystit.com/photos/c85f-2014/04/08/gucci-brown-light-brown-leather-gg-stitched-detail-shoulder-bag-product-1-19046497-3-437678460-normal.jpeg" },
                new ShopItem {Name = "Louis Vuitton Hand Bag Light Black" , Status ="Almost New" , Price = "3000.00"  , ImgSource = "https://cdnd.lystit.com/photos/c85f-2014/04/08/gucci-brown-light-brown-leather-gg-stitched-detail-shoulder-bag-product-1-19046497-3-437678460-normal.jpeg" },
                new ShopItem {Name = "Balenciaga Hand Bag Light Dark" , Status ="Almost New" , Price = "3000.00"  , ImgSource = "https://cdnd.lystit.com/photos/c85f-2014/04/08/gucci-brown-light-brown-leather-gg-stitched-detail-shoulder-bag-product-1-19046497-3-437678460-normal.jpeg" },

            };
		    MyListView.ItemsSource = ShopItems;
		}

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            (sender as ListView).SelectedItem = null;

            if (e.Item != null)
            {
                ShopItem shopi = e.Item as ShopItem;
                DisplayAlert("Produit : " + shopi.Name, "Le Prix est : " + shopi.Price, "OK");

            }

            //await DisplayAlert("Item Tapped", "An item was tapped."+e.ToString(), "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

	    private void SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
	    {

            List<ShopItem> results = ShopItems.FindAll(
                delegate(ShopItem bk) { return bk.Name.Contains(SearchBar_Text.Text); }
            );
	        if (results.Count != 0)
	        {
	            MyListView.ItemsSource = results;
            }
	        else
	        {
	            List<ShopItem> noresults = new List<ShopItem> {
	                new ShopItem {Name = "No Results Found" , Status =" " , Price = " "  , ImgSource = " " },
	             };

	            MyListView.ItemsSource = noresults ;

	        }
        }

	    private void SearchBar_Text_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        if (string.IsNullOrEmpty(SearchBar_Text.Text))
	        {
	            MyListView.ItemsSource = ShopItems;
            }
	        else
	        {
                List<ShopItem> results = ShopItems.FindAll(
               delegate (ShopItem bk) { return bk.Name.Contains(SearchBar_Text.Text); }
           );
                if (results.Count != 0)
                {
                    MyListView.ItemsSource = results;
                }
                else
                {
                    List<ShopItem> noresults = new List<ShopItem> {
                    new ShopItem {Name = "No Results Found" , Status =" " , Price = " "  , ImgSource = " " },
                 };

                    MyListView.ItemsSource = noresults;

                }
            }
	    }
	}
}
