using Android.App;
using Microsoft.Identity.Client;
using Android.Content;

namespace ContagemConsignados.Platforms.Android
{
    [Activity(Exported = true)]
    [IntentFilter(new[] {Intent.ActionView},
                    Categories = new[] {Intent.CategoryBrowsable, Intent.CategoryDefault},
                    DataHost ="auth",
                    DataScheme = "msal786ebac0-2995-4a3d-9875-72661c650b49")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}
