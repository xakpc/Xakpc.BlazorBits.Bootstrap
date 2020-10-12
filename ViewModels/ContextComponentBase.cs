using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Xakpc.BlazorBits.Bootstrap.ViewModels
{

    /// <summary>
    /// ComponentBase with DataContext
    /// </summary>
    public class ContextComponentBase : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected ViewModelBase DataContext { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            if (DataContext == null) return;

            if (!DataContext.Initialized) // do once
            {
                await DataContext.InitializeAsync();
                DataContext.PropertyChanged += (s, e) => StateHasChanged();
            }

            await base.OnInitializedAsync();
        }
    }
}