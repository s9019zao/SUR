﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SUR_CSTG.Data;

namespace SUR_CSTG.ViewModels.DeviceViewModels
{
    public class EditDeviceWindowViewModel : ViewModel
    {
        #region Fields

        DeviceViewModel _deviceViewModel;
        Device _deviceToEdit;
        Area _selectedArea;
        Area _areaToEdit;
        SUR_DbContext _ctx = new SUR_DbContext();
        ICommand _closeWinndow;
        ICommand _edit;
        string _name;
        string _description;

        #endregion

        #region Constructors

        public EditDeviceWindowViewModel(DeviceViewModel deviceViewModel)
        {
            _deviceViewModel = deviceViewModel;
            GetAreas();
           
        }

        #endregion

        #region Properities

        public ObservableCollection<Area> AllAreas { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("");
            }
        }


        public string Description
        {
            get { return _description; }
            set
            {
                _description = value; ;
                OnPropertyChanged("");
            }
        }

        public Area AreaToEdit
        {
            get { return _areaToEdit; }
            set
            {
                _areaToEdit = value;
                OnPropertyChanged("");
            }
        }

        public Area SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                _selectedArea = value;
                OnPropertyChanged("");
            }
        }

        public DeviceViewModel DeviceViewModel
        {
            get { return _deviceViewModel; }
            set
            {
                _deviceViewModel = value;

                OnPropertyChanged("");
            }
        }

        public Device DeviceToEdit
        {
            get { return _deviceToEdit; }
            set
            {
                _deviceToEdit = value;
                Name = value.Name;
                Description = value.Description;
                AreaToEdit = value.Area;
                OnPropertyChanged("");
            }
        }

        public void GetAreas()
        {
            AllAreas = new ObservableCollection<Area>(_ctx.Areas);
        }

        #endregion

        #region Command

        public ICommand EditCommand
        {
            get { return _edit ?? (_edit = new RelayCommand(Edit)); }
        }

        public void Edit(object obj)
        {
            DeviceToEdit.Name = Name;
            DeviceToEdit.Description = Description;
            DeviceToEdit.Area = SelectedArea;
            _ctx.SaveChanges();
            Close(obj);
        }

        public ICommand CloseCommand
        {
            get { return _closeWinndow ?? (_closeWinndow = new RelayCommand(Close)); }
        }
        public void Close(object obj)
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }

        #endregion
    }
}