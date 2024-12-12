using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace ExamenMVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string product1;

        [ObservableProperty]
        private string product2;

        [ObservableProperty]
        private string product3;

        [ObservableProperty]
        private decimal subtotal;

        [ObservableProperty]
        private decimal discount;

        [ObservableProperty]
        private decimal total;

        [ObservableProperty]
        private string errorMessage;

        [RelayCommand]
        private void CalculateDiscount()
        {
            try
            {
                decimal p1 = GetDecimalValue(Product1);
                decimal p2 = GetDecimalValue(Product2);
                decimal p3 = GetDecimalValue(Product3);

                Subtotal = p1 + p2 + p3;

                if (Subtotal >= 10000)
                    Discount = 0.3m * Subtotal;
                else if (Subtotal >= 5000)
                    Discount = 0.2m * Subtotal;
                else if (Subtotal >= 1000)
                    Discount = 0.1m * Subtotal;
                else
                    Discount = 0;

                Total = Subtotal - Discount;
                ErrorMessage = string.Empty;
            }
            catch (Exception)
            {
                Subtotal = 0;
                Discount = 0;
                Total = 0;
                ErrorMessage = "Por favor, ingrese valores válidos para los productos.";
            }
        }

        [RelayCommand]
        private void Limpiar()
        {
            Product1 = string.Empty;
            Product2 = string.Empty;
            Product3 = string.Empty;
            Subtotal = 0;
            Discount = 0;
            Total = 0;
            ErrorMessage = string.Empty;
        }

        private decimal GetDecimalValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;
            else
                return decimal.Parse(value);
        }
    }
}