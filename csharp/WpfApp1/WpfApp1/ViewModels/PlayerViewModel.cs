using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsoleApp1.Models;
using ConsoleApp1.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public partial class PlayerViewModel: ObservableObject
    {
        private readonly PlayerRepo _repo;

        public PlayerViewModel(PlayerRepo repo)
        {
            _repo = repo;
            Update();
        }

        [ObservableProperty]
        public List<Player> _jatekosok;

        [ObservableProperty]
        public Player _currentPlayer;

        [ObservableProperty]
        public string _name;

        [ObservableProperty]
        public string _email;

        [ObservableProperty]
        public int _amount;



        [RelayCommand]
        public void Nullaz()
        {
            CurrentPlayer = new Player();
        }

        [RelayCommand]
        public async Task EditPlayer()
        {
            if(CurrentPlayer != null && !string.IsNullOrEmpty(CurrentPlayer.Name) && CurrentPlayer.Amount>=0)
            {
                await _repo.EditPlayer(CurrentPlayer);
                await Update();
            }
        }

        [RelayCommand]
        public async Task Add()
        {
            if (CurrentPlayer != null && !string.IsNullOrEmpty(CurrentPlayer.Name) && CurrentPlayer.Amount >= 0)
            {
                await _repo.AddPlayer(CurrentPlayer);
                await Update();
            }
        }

        [RelayCommand]
        public async Task DeleteIfNoAmount()
        {
            await _repo.DeleteIfNoAmount(CurrentPlayer);
            await Update();
        }

        public async Task Update()
        {
            Jatekosok =  _repo.GetAll();
        }
    }
}
