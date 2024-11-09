using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Snackbar;
using AlertDialog = Android.App.AlertDialog;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private int _count;
        private bool _clearData;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var countButton = FindViewById<Button>(Resource.Id.increaseNumberButton);
            countButton!.Click += (sender, args) =>
            {
                var countNumberView = FindViewById<TextView>(Resource.Id.countNumberView);
                countNumberView!.Text = $"Count: {_count++}";
            };

            var showAlertButton = FindViewById<Button>(Resource.Id.showAlertDialogButton);
            showAlertButton!.Click += (sender, args) =>
            {
                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("TestTitle");
                dialog.SetMessage("Hello world!");
                dialog.SetNegativeButton("Cancel", (o, eventArgs) => { });
                dialog.SetPositiveButton("Ok", (o, eventArgs) => { });
                dialog.Show();
            };

            var loadTextButton = FindViewById<Button>(Resource.Id.loadTextButton);
            loadTextButton!.Click += async (sender, args) =>
            {
                var loadTextView = FindViewById<TextView>(Resource.Id.loadTextView);
                using var reader = new StreamReader(Assets!.Open("lyric.txt"));
                var text = await reader.ReadToEndAsync();
                loadTextView!.Text = text;
            };

            var viewMusicInfoButton = FindViewById<Button>(Resource.Id.viewMusicInfoButton);
            viewMusicInfoButton!.Click += (sender, args) =>
            {
                var intent = new Intent(this, typeof(MusicInfoActivity));
                StartActivity(intent);
            };
        }

        private void ClearData()
        {
            _count = 0;
            var countNumberView = FindViewById<TextView>(Resource.Id.countNumberView);
            countNumberView!.Text = $"Count: 0";
            _clearData = true;
        }

        protected override void OnPause()
        {
            base.OnPause();
            ClearData();
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (!_clearData) return;
            Snackbar.Make(FindViewById<ViewGroup>(Resource.Id.rootLayout), "Count has been deleted!!",
                3000).Show();
            _clearData = false;
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}