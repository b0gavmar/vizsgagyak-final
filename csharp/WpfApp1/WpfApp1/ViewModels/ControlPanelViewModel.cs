using CommunityToolkit.Mvvm.ComponentModel;
using ConsoleApp1.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public partial class ControlPanelViewModel:ObservableObject
    {
        private readonly PlayerRepo _repo;

        public ControlPanelViewModel(PlayerRepo repo)
        {
            _repo = repo;
            Update();
        }

        [ObservableProperty]
        public string _noMoney;

        [ObservableProperty]
        public string _legalabb10k;

        [ObservableProperty]
        public string _osszOsszeg;

        public void Update()
        {
            NoMoney = "Keretösszeg nélküli játékosok száma: "+_repo.GetNumberOfPlayersWithoutAmount() +" fő";
            Legalabb10k = "Legalább 10ezer keretösszeggel rendelkezők száma: "+_repo.Legalabb10K()+" fő";
            OsszOsszeg = "Összes összeg: " +_repo.GetSumOfAllAmount()+ "Ft";
        }
    }
}
