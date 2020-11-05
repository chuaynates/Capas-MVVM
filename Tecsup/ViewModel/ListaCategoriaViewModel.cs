using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Entity;


namespace Tecsup.ViewModel
{
    public class ListaCategoriaViewModel : ViewModelBase
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        public ICommand SelectedItem { get; set; }
        public ICommand NuevoCommand { set; get; }
        public ICommand ConsultarCommand { set; get; }
    public ListaCategoriaViewModel()
    {
            Categorias = new Model.CategoriaModel().Categorias;

            SelectedItem = new RelayCommand<Window>(
              o => {
                  int idCategoria = 0;
                  idCategoria = Convert.ToInt32(SelectedItem);
                  View.ManCategoria window = new View.ManCategoria(idCategoria);
                  window.ShowDialog();
              });

            NuevoCommand = new RelayCommand<Window>(
                param => Abrir()
                );
            ConsultarCommand = new RelayCommand<object>(
                o => { Categorias = new Model.CategoriaModel().Categorias; }
                );
            void Abrir()
            {
                View.ManCategoria window = new View.ManCategoria(0);
                window.ShowDialog();
                //Categorias = (new Model.CategoriaModel()).Categorias;
            }


    }
        
    }
}
