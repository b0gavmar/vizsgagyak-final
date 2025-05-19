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
        }

        public void Update()
        {

        }
    }
}
