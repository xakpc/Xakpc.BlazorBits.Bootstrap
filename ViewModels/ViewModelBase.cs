using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Xakpc.BlazorBits.Bootstrap.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Flag indicator if ViewModel was initialized. Set to true by InitializeAsync Method
        /// Used to avoid double initialization for ServerPrerendered mode
        /// </summary>
        public bool Initialized { get; set; }

        /// <summary>
        /// Initialize view model
        /// </summary>
        /// <returns></returns>
        /// <remarks>This method should not use any JSInterop if render mode is ServerPrerendered</remarks>
        public virtual Task InitializeAsync()
        {
            Initialized = true;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        // ReSharper disable once UnusedMember.Global
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}