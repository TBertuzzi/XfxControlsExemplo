using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XfxControlsExemplo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        public ObservableCollection<string> Usuarios { get; }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _usuarioSelecionado;
        public string UsuarioSelecionado
        {
            get => _usuarioSelecionado;
            set => SetProperty(ref _usuarioSelecionado, value);
        }


        public MainViewModel()
        {
            Usuarios = new ObservableCollection<string>();

            var user = new Usuario();
            Usuarios.Add("Bertuzzi");

            user = new Usuario();
            Usuarios.Add("Bruna");

            user = new Usuario();
            Usuarios.Add("Polly");

            user = new Usuario();
            Usuarios.Add("Rodolfo");

            user = new Usuario();
            Usuarios.Add("Lester");


        }

    }
}
