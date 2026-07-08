using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace OrderManagement.Mobile.ViewModels;

public class BindingExampleViewModel : INotifyPropertyChanged
{
    private string _userName = string.Empty;
    private string _email = string.Empty;
    private string _resultMessage = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName == value)
            {
                return;
            }

            _userName = value;
            OnPropertyChanged();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (_email == value)
            {
                return;
            }

            _email = value;
            OnPropertyChanged();
        }
    }

    public string ResultMessage
    {
        get => _resultMessage;
        set
        {
            if (_resultMessage == value)
            {
                return;
            }

            _resultMessage = value;
            OnPropertyChanged();
        }
    }

    public ICommand SaveCommand { get; }

    public BindingExampleViewModel()
    {
        SaveCommand = new Command(ExecuteSave);
    }

    private void ExecuteSave()
    {
        ResultMessage = $"Bonjour {UserName}, votre email est {Email}";
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
