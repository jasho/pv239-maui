﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace PV239_06_API.Core.Models
{
    public class ModelBase : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}