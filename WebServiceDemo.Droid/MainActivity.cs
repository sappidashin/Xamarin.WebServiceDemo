using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using WebServiceDemo.Service;

namespace WebServiceDemo.Droid
{
    [Activity(Label = "WebServiceDemo.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected  override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            MyService service = new MyService();
            button.Click +=async (sender,e)=>
            {
                var result =await service.GetData(999);
                Toast.MakeText(this, result, ToastLength.Long).Show();
            };

           
        }
    }
}

