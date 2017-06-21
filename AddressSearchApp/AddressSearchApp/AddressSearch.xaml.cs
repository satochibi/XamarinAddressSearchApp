using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddressSearchApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddressSearch : ContentPage
	{
		public AddressSearch ()
		{
			InitializeComponent ();
            this.Title = "住所検索アプリ";
            getAddressSearchBtn.Clicked += GetAddressSearchBtn_Clicked;
            this.BindingContext = new Address();
		}

        private async void GetAddressSearchBtn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AddressEntry.Text) && ((string)AddressEntry.Text).Length == 7)
            {
                Address Ad = await Core.GetAddressSearchResult(AddressEntry.Text);
                if (Ad == null)
                {
                    await DisplayAlert("通知", "検索に失敗しました。条件を変更して再度検索してください。", "OK");
                    return;
                }
                else
                {
                    this.BindingContext = Ad;
                }

            }
            else
            {
                await DisplayAlert("警告", "郵便番号は7桁で入力してください。", "OK");
            }
        }

    }
}