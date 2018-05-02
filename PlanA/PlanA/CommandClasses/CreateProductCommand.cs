﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PlanA.CatalogClasses;
using PlanA.ProductClasses;

namespace PlanA.CommandClasses
{
    class CreateProductCommand : ICommand
    {
        private IProduct _product;
        private ProductCatalog _productCatalog;

        public CreateProductCommand(IProduct product, ProductCatalog productCatalog)
        {
            _product = product;
            _productCatalog = productCatalog;
        }

        public bool CanExecute(object parameter)
        {
            if (_productCatalog.GetProductCatalog.ContainsKey(_product.ProductID))
            {
                return false;
            }
            return true;

        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}