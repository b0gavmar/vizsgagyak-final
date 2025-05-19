using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsoleApp1.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        private readonly PlayerRepo _repo;

        [ObservableProperty]
        public PlayerViewModel _playersViewModel;

        [ObservableProperty]
        public ControlPanelViewModel _controlPanelsViewModel;

        [ObservableProperty]
        public object _currentViewModel;

        public MainViewModel()
        {
            _repo = new PlayerRepo();
            _playersViewModel = new PlayerViewModel(_repo);
            _controlPanelsViewModel = new ControlPanelViewModel(_repo);

            CurrentViewModel = ControlPanelsViewModel;
        }

        [RelayCommand]
        public void ShowPlayers()
        {
            PlayersViewModel.Update();
            CurrentViewModel = PlayersViewModel;
        }

        [RelayCommand]
        public void ShowControlPanel()
        {
            ControlPanelsViewModel.Update();
            CurrentViewModel = ControlPanelsViewModel;
        }
    }
}
