﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DragAndDrop
{

    public class NotifyPropertyChanged
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
