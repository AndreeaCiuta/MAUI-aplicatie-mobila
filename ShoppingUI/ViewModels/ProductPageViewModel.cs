using System;
using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Input;

namespace ShoppingUI
{
    public class ProductPageViewModel
    {
        public ObservableCollection<Items> Items { get; set; }

        public ObservableCollection<Items> CartItems { get; set; }
     
        public Items SelectedItem { get; set; }

        public ICommand Itemclick { get; set; }
        public ICommand CartItemclick { get; set; }
        public ProductPageViewModel(INavigation navigation)
        {
            Items = new ObservableCollection<Items>
            {
                new Items
                {
                    Imagine="albastru.png",
                    Nume = "DAVIDOFF COOL WATER INTENSE",
                    Cantitate = "1",
                    Pret = "520 LEI",
                    Descriere = "Baza acestui parfum Davidoff Cool este o compoziție în schimbare a contrastelor - un miros care ajunge sub pielea unei persoane. Evocă senzualitatea forțelor calmante și misterul apei. Barbatul Cool Water este un individ care este conștient de masculinitatea și corpul său. În 1992, acest parfum de la Davidoff a devenit cel mai bun parfum pentru bărbați"
                },
                new Items
                {
                    Imagine="irres.png",
                    Nume = "LANVIN ÉCLAT D´ARPEGE",
                    Cantitate = "1",
                    Pret = "430 LEI",
                    Descriere ="Prezentat într-o sticlă violet care evocă o adevărată bijuterie, parfumul Lanvin Éclat D'Arpege este o creație modernă pe tema iubirii. Bucurați-vă de zile frumoase pline de momente unice, cu un parfum care evocă amintirile fericite ale verii. Brandul Lanvin a intrat în lumea parfumurilor în 1924 și fiecare dintre parfumurile sale este unic și excepțional."
                },
                new Items
                {
                    Imagine="kalvin.png",
                    Nume = "CALVIN KLEIN EUPHORIA INTENSE",
                    Cantitate = "1",
                    Pret = "256 LEI",
                    Descriere ="Răsfățați-vă în amestecul magistral de înflăcărare și eleganță întruchipat de apa de parfum Calvin Klein Euphoria Intense! Lansat în 2021 de către simbolul american al modei, Calvin Klein. Parfumurile sale Obsession, CK One și Euphoria se numără printre cele mai dorite din lume. Apa de parfum picantă Euphoria Intense Eau de Parfum va crea pe pielea ta un parfum irezistibil de fructe, lemnos, patchouli și floral."
                },
                new Items
                {
                    Imagine="parfum.png",
                    Nume = "GIVENCHY IRRESISTIBLE",
                    Cantitate = "1",
                    Pret = "456 LEI",
                    Descriere = "În timpul creației societății pariziene Givenchy la Paris în 1952, Hubert de Givenchy nu avea idee că va fi unul dintre cele mai de succes.  Timp de 40 de ani, rochia marca Givenchy va fi purtată de Audrey Hepburn, cu liniile sale elegante atât in oraș cat și pe ecran, în Sabrina, Drôle de frimousse sau Diamants sur canapé."
                },
                new Items
                {
                    Imagine="ruxi.png",
                    Nume = "CHOPARD HAPPY CHOPARD FELICIA ROSES",
                    Cantitate = "1",
                    Pret = "100 LEI",
                    Descriere ="Chopard este una dintre companiile de bijuterii care au decis să ofere clienților lor parfumuri. Spre deosebire de brandurile de parfumuri care atrag atenția, Chopard rămâne discret, cu toate acestea gama de alegeri este incredibil de interesantă. Iubitorii de parfumuri  orientale își vor găsi un preferat printre produsele brandului Chopard."
                },
                new Items
                {
                    Imagine="top.png",
                    Nume = "SET PARFUMURI TOP",
                    Cantitate = "1",
                    Pret = "700 LEI",
                    Descriere ="De ce v-ați limita la un singur parfum, când există atâtea? Setul de parfumuri unisex Beauty Discovery Box este modul ideal de a încerca mai multe compoziții parfumate. Alternați parfumurile în funcție de dispoziție sau de ocazie și savurați diversitatea oferită de acest set."
                }
            };
            CartItems = new ObservableCollection<Items> { };
            Itemclick = new Command<Items>(executeitemclickcommand);
            CartItemclick = new Command<Items>(executeCartitemclickcommand);
           
            this.navigation = navigation;
        }
        private INavigation navigation;

        async void executeitemclickcommand(Items item)
        {
            this.SelectedItem = item;
            await navigation.PushModalAsync(new DetailsPage(this));
        }

        async void executeCartitemclickcommand(Items item)
        {
            this.CartItems.Add(this.SelectedItem);
            await navigation.PushModalAsync(new CartPage(this));

        }
       
    }
}
